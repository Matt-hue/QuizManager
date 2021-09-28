using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManager.Infrastructure.TagHelpers
{
    [HtmlTargetElement(TAG, Attributes = "asp-policy")]
    [HtmlTargetElement(TAG, Attributes = "asp-authentication-schemes")]
    [HtmlTargetElement(TAG, Attributes = "asp-roles")]
    public class RoleAccessTagHelper : TagHelper, IAuthorizeData
    {
        private const string TAG = "role-access";

        private readonly IAuthorizationPolicyProvider _policyProvider;
        private readonly IPolicyEvaluator _policyEvaluator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RoleAccessTagHelper(
            IAuthorizationPolicyProvider policyProvider, 
            IPolicyEvaluator policyEvaluator, 
            IHttpContextAccessor httpContextAccessor)
        {
            _policyProvider = policyProvider ?? throw new ArgumentNullException(nameof(policyProvider));
            _policyEvaluator = policyEvaluator ?? throw new ArgumentNullException(nameof(policyEvaluator));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        /// <summary>
        /// Gets or sets the policy name that determines access to the HTML block.
        /// </summary>
        [HtmlAttributeName("asp-policy")]
        public string Policy { get; set; }

        /// <summary>
        /// Gets or sets a comma delimited list of roles that are allowed to access the HTML  block.
        /// </summary>
        [HtmlAttributeName("asp-roles")]
        public string Roles { get; set; }

        /// <summary>
        /// Gets or sets a comma delimited list of schemes from which user information is constructed.
        /// </summary>
        [HtmlAttributeName("asp-authentication-schemes")]
        public string AuthenticationSchemes { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var policy = await AuthorizationPolicy.CombineAsync(_policyProvider, new[] { this });

            var authenticateResult = await _policyEvaluator.AuthenticateAsync(policy, _httpContextAccessor.HttpContext);

            var authorizeResult = await _policyEvaluator.AuthorizeAsync(policy, authenticateResult, _httpContextAccessor.HttpContext, null);

            if (!authorizeResult.Succeeded)
            {
                output.SuppressOutput();
            }

            if (output.Attributes.TryGetAttribute("asp-authorize", out TagHelperAttribute attribute))
                output.Attributes.Remove(attribute);
        }
    }
}

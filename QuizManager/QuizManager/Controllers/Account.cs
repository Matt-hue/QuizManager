using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizManager.EntityFramework.Models;
using QuizManager.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace QuizManager.Controllers
{
    [Authorize]
    public class Account : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public Account(
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindByEmailAsync(viewModel.Email);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Incorrect email/password combination");
                    return View(viewModel);
                }

                SignInResult result = await _signInManager.PasswordSignInAsync(user.UserName, viewModel.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction(controllerName: nameof(Quiz), actionName: nameof(Quiz.List));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Incorrect email/password combination");
                    return View(viewModel);
                }
            }
            else
            {
                return View(viewModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToActionPermanent(nameof(Login));
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}

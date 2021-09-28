using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManager.Models.Account
{
    public class LoginViewModel
    {
        [EmailAddress]
        [Required]
        [Display(Name = "Email", Prompt = "Enter your email address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt = "Enter your password")]
        public string Password { get; set; }
    }
}

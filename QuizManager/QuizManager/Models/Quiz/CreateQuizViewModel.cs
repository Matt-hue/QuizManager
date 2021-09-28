using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManager.Models.Quiz
{
    public class CreateQuizViewModel
    {
        [Required]
        [StringLength(600)]
        [Display(Name = "Quiz Title", Prompt = "Enter the title of your new quiz here")]
        public string Title { get; set; }
    }
}

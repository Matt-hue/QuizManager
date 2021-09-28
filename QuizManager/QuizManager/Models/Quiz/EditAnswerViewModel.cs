using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManager.Models.Quiz
{
    public class EditAnswerViewModel
    {
        public int QuizId { get; set; }
        public int AnswerId { get; set; }
        [Required]
        [StringLength(1000)]
        [Display(Name = "Answer", Prompt = "Update your answer")]
        public string TitleUpdate { get; set; }
    }
}

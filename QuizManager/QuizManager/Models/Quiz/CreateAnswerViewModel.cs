using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManager.Models.Quiz
{
    public class CreateAnswerViewModel
    {
        public int QuizId { get; set; }
        public int QuestionId { get; set; }
        [Required]
        [StringLength(1000)]
        [Display(Name = "Answer", Prompt = "Add a new answer")]
        public string Title { get; set; }
    }
}

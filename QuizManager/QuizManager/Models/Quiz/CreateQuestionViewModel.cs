using QuizManager.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManager.Models.Quiz
{
    [AnswerListSizeValidation(3, 5)]
    public class CreateQuestionViewModel
    {
        public int QuizId { get; set; }
        [Required]
        [StringLength(1000)]

        [Display(Name = "Quiz Question", Prompt = "Enter a title for your question")]
        public string QuestionTitle { get; set; }
        [StringLength(1000)]
        [Display(Name = "Answer A")]
        public string AnswerA { get; set; }
        [StringLength(1000)]
        [Display(Name = "Answer B")]
        public string AnswerB { get; set; }
        [StringLength(1000)]
        [Display(Name = "Answer C")]
        public string AnswerC { get; set; }
        [StringLength(1000)]
        [Display(Name = "Answer D")]
        public string AnswerD { get; set; }
        [StringLength(1000)]
        [Display(Name = "Answer E")]
        public string AnswerE { get; set; }

    }
}

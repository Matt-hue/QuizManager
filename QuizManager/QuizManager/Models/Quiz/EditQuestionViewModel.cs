using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManager.Models.Quiz
{
    public class EditQuestionViewModel
    {
        public int QuizId { get; set; }
        public int QuestionId { get; set; }
        [Required]
        [StringLength(1000)]
        [Display(Name = "Question", Prompt = "Update your Question")]
        public string TitleUpdate { get; set; }
    }
}

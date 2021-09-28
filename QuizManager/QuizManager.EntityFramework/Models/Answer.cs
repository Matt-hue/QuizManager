using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuizManager.EntityFramework.Models
{
    public class Answer
    {
        public int Id { get; set; }
        [MaxLength(1000)]
        public string Title { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuizManager.EntityFramework.Models
{
    public class ApplicationQuiz
    {
        public int Id { get; set; }
        [MaxLength(600)]
        public string Title { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuizManager.EntityFramework.Models
{
    public class Question
    {
        public int Id { get; set; }
        [MaxLength(1000)]
        public string Title { get; set; }
        public int Order { get; set; }
        public int QuizId { get; set; }
        public ApplicationQuiz Quiz { get; set; }
        public ICollection<Answer> Answers { get; set; }

        public void UpdateOrder(int order)
        {
            this.Order = order;
        }
    }
}

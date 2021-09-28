using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManager.Models.Quiz
{
    public class QuizModel
    {
        public int QuizId { get; set; }
        public string Title { get; set; }
        public int QuestionCount { get; set; }
    }
}

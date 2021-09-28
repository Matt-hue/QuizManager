using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManager.Models.Quiz
{
    public class QuestionModel
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public IEnumerable<AnswerModel> Answers { get; set; }
    }
}

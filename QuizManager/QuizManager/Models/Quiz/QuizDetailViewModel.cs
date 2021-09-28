using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManager.Models.Quiz
{
    public class QuizDetailViewModel
    {
        public int QuizId { get; set; }
        public string QuizTitle { get; set; }
        public IEnumerable<QuestionModel> Questions { get; set; }
    }
}

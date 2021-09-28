using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManager.Models.Quiz
{
    public class QuizListViewModel
    {
        public IEnumerable<QuizModel> Quizzes { get; set; }
        public QuizModel[] QuizzArray => this.Quizzes.ToArray();
    }
}

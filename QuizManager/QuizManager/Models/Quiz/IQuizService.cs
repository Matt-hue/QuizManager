using Microsoft.AspNetCore.Mvc.ModelBinding;
using QuizManager.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace QuizManager.Models.Quiz
{
    public interface IQuizService
    {
        Task<int> CreateQuizAsync(CreateQuizViewModel viewModel);
        QuizListViewModel GetQuizzes();
        Task CreateQuestionAsync(CreateQuestionViewModel viewModel);
        Task<QuizDetailViewModel> GetQuizAsync(int id);
        Task DeleteQuizAsync(int id);
        Task DeleteQuestionAsync(int questionId);
        Task UpdateQuestionAsync(int questionId, string entry);
        Task UpdateAnswerAsync(int answerId, string titleUpdate);
        Task DeleteAnswerAsync(int answerId);
        Task CreateAnswerAsync(int questionId, string title);
        Task ReorderQuestionAsync(int quizId, int questionId, int position);
    }
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepository;

        public QuizService(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository ?? throw new ArgumentNullException(nameof(quizRepository));
        }

        public async Task CreateAnswerAsync(int questionId, string title)
        {

            await _quizRepository.CreateAnswerAsync(questionId, title);
            await _quizRepository.SaveChangesAsync();
        }

        public async Task CreateQuestionAsync(CreateQuestionViewModel viewModel)
        {
            var answers = new List<Answer>();

            PropertyInfo[] properties = typeof(CreateQuestionViewModel).GetProperties();
            foreach (var p in properties)
            {
                if (p.PropertyType == typeof(string) && p.Name.Contains("Answer"))
                {
                    var answer = (string)p.GetValue(viewModel);
                    if (!string.IsNullOrWhiteSpace(answer))
                    {
                        answers.Add(new Answer()
                        {
                            Title = answer
                        });
                    }
                }
            }

            if(answers.Count() < 3 || answers.Count() > 5)
            {
                throw new Exception("There must be between 3-5 valid answers");
            }

            ApplicationQuiz quiz = await _quizRepository.GetQuizAsync(viewModel.QuizId);
            int highestOrder;
            if (!quiz.Questions.Any())
            {
                highestOrder = -1;
            }
            else
            {
                //Question highestOrder = quiz.Questions.Aggregate((agg, next) => agg.Order > next.Order ? agg : next);
                highestOrder = quiz.Questions.Max(qu => qu.Order);
            }

            int newOrder = highestOrder + 1;

            Question question = new Question()
            {
                QuizId = viewModel.QuizId,
                Title = viewModel.QuestionTitle,
                Order = newOrder,
                Answers = answers
            };

            await _quizRepository.CreateQuestionAsync(question);
            await _quizRepository.SaveChangesAsync();
        }

        public async Task<int> CreateQuizAsync(CreateQuizViewModel viewModel)
        {
            ApplicationQuiz quiz = await _quizRepository.CreateQuizAsync(viewModel.Title);
            await _quizRepository.SaveChangesAsync();
            return quiz.Id;
        }

        public async Task DeleteAnswerAsync(int answerId)
        {
            await _quizRepository.DeleteAnswerAsync(answerId);
            await _quizRepository.SaveChangesAsync();
        }

        public async Task DeleteQuestionAsync(int questionId)
        {
            await _quizRepository.DeleteQuestionAsync(questionId);
            await _quizRepository.SaveChangesAsync();
        }

        public async Task DeleteQuizAsync(int quizId)
        {
            await _quizRepository.DeleteQuizAsync(quizId);
            await _quizRepository.SaveChangesAsync();
        }

        public async Task<QuizDetailViewModel> GetQuizAsync(int id)
        {
            ApplicationQuiz quiz = await _quizRepository.GetQuizAsync(id);

            IEnumerable<QuestionModel> questionModel = quiz.Questions.Select(qu =>
                                                            new QuestionModel()
                                                            {
                                                                QuestionId = qu.Id,
                                                                Title = qu.Title,
                                                                Order = qu.Order,
                                                                Answers = qu.Answers.Select(ans =>
                                                                new AnswerModel()
                                                                {
                                                                    AswerId = ans.Id,
                                                                    Title = ans.Title
                                                                })
                                                            });

            IOrderedEnumerable<QuestionModel> orderedQuestions = questionModel.OrderBy(qu => qu.Order);

            var viewModel = new QuizDetailViewModel()
            {
                QuizId = quiz.Id,
                QuizTitle = quiz.Title,
                Questions = orderedQuestions
            };

            return viewModel;
        }

        public QuizListViewModel GetQuizzes()
        {
            List<ApplicationQuiz> quizzes = _quizRepository.GetQuizzes();

            var listViewModel = new QuizListViewModel()
            {
                Quizzes = quizzes.Select(q =>
                new QuizModel()
                {
                    QuizId = q.Id,
                    Title = q.Title,
                    QuestionCount = q.Questions.Count()
                })
            };

            return listViewModel;
        }


        public async Task ReorderQuestionAsync(int quizId, int questionId, int position)
        {
            Question questionBeingMoved = await _quizRepository.GetQuestionAsync(questionId);
            int oldPosition = questionBeingMoved.Order;

            List<Question> allQuestions = await _quizRepository.GetAllQuestionsAsync(quizId);

            bool directionPositive = (position > oldPosition);

            if (directionPositive)
            {
                Question questionAhead = allQuestions.FirstOrDefault(qu => qu.Order == oldPosition + 1);
                if (questionAhead == null)
                {
                    return;
                }

                var questionAheadOldPosition = questionAhead.Order;

                questionAhead.UpdateOrder(questionAheadOldPosition-1);
                questionBeingMoved.UpdateOrder(position);
            }
            else if (!directionPositive)
            {
                Question questionBehind = allQuestions.FirstOrDefault(qu => qu.Order == oldPosition - 1);
                if (questionBehind == null)
                {
                    return;
                }

                var questionBehindOldPosition = questionBehind.Order;

                questionBehind.UpdateOrder(questionBehindOldPosition + 1);
                questionBeingMoved.UpdateOrder(position);
            }

            await _quizRepository.SaveChangesAsync();
        }

        public async Task UpdateAnswerAsync(int answerId, string titleUpdate)
        {
            await _quizRepository.UpdateAnswerAsync(answerId, titleUpdate);
            await _quizRepository.SaveChangesAsync();
        }

        public async Task UpdateQuestionAsync(int questionId, string titleUpdate)
        {
            await _quizRepository.UpdateQuestionAsync(questionId, titleUpdate);
            await _quizRepository.SaveChangesAsync();
        }
    }
}

using QuizManager.Data;
using QuizManager.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace QuizManager.Models.Quiz
{
    public interface IQuizRepository
    {
        Task<ApplicationQuiz> CreateQuizAsync(string title);
        Task SaveChangesAsync();
        List<ApplicationQuiz> GetQuizzes();
        Task CreateQuestionAsync(Question question);
        Task<ApplicationQuiz> GetQuizAsync(int id);
        Task DeleteQuizAsync(int id);
        Task DeleteQuestionAsync(int questionId);
        Task UpdateQuestionAsync(int questionId, string entry);
        Task UpdateAnswerAsync(int answerId, string titleUpdate);
        Task DeleteAnswerAsync(int answerId);
        Task CreateAnswerAsync(int questionId, string title);
        Task<Question> GetQuestionAsync(int questionId);
        Task<List<Question>> GetAllQuestionsAsync(int quizId);
    }

    public class QuizRepository : IQuizRepository
    {
        private readonly ApplicationDbContext _context;

        public QuizRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //Your missing a change for polymorphism here. use it 
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<ApplicationQuiz> CreateQuizAsync(string title)
        {
            var newQuiz = new ApplicationQuiz()
            {
                Title = title
            };
            var entity = await _context.AddAsync<ApplicationQuiz>(newQuiz);

            return entity.Entity;
        }

        public List<ApplicationQuiz> GetQuizzes()
        {
            var quizzes = _context.Quizzes
                            .Include(q => q.Questions)
                            .ToList();

            return quizzes;
        }

        public async Task CreateQuestionAsync(Question question)
        {
            await _context.AddAsync<Question>(question);
        }

        public async Task<ApplicationQuiz> GetQuizAsync(int id)
        {
            var quiz = await _context.Quizzes
                                .Include(q => q.Questions)
                                    .ThenInclude(qu => qu.Answers)
                                .FirstOrDefaultAsync(q => q.Id == id);
            return quiz;
        }

        public async Task DeleteQuizAsync(int quizId)
        {
            var quiz = await _context.Quizzes.FindAsync(quizId);
            _context.Remove(quiz);
        }

        public async Task DeleteQuestionAsync(int questionId)
        {
            var question = await _context.Questions.FindAsync(questionId);
            _context.Remove(question);
        }

        public async Task UpdateQuestionAsync(int questionId, string entry)
        {
            var question = await _context.Questions.FindAsync(questionId);
            question.Title = entry;
            _context.Entry(question).State = EntityState.Modified;
        }

        public async Task UpdateAnswerAsync(int answerId, string titleUpdate)
        {
            var question = await _context.Answers.FindAsync(answerId);
            question.Title = titleUpdate;
            _context.Entry(question).State = EntityState.Modified;
        }

        public async Task DeleteAnswerAsync(int answerId)
        {
            var answer = await _context.Answers.FindAsync(answerId);
            _context.Remove(answer);
        }

        public async Task CreateAnswerAsync(int questionId, string title)
        {
            var newAnswer = new Answer()
            {
                QuestionId = questionId,
                Title = title
            };

            await _context.AddAsync<Answer>(newAnswer);
        }

        public async Task<Question> GetQuestionAsync(int questionId)
        {
            Question question = await _context.Questions
                                            .Include(qu => qu.Answers)
                                            .FirstOrDefaultAsync(qu => qu.Id == questionId);

            return question;
        }

        public async Task<List<Question>> GetAllQuestionsAsync(int quizId)
        {
            List<Question> questions = await _context.Questions
                                        .Where(qu => qu.QuizId == quizId)
                                        .Include(qu => qu.Quiz)
                                        .ToListAsync();

            return questions;
        }
    }
}

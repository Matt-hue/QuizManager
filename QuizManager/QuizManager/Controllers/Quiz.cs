using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizManager.Constants;
using QuizManager.Models.Quiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManager.Controllers
{
    [Authorize]
    public class Quiz : Controller
    {
        private readonly IQuizService _quizService;

        public Quiz(IQuizService quizService)
        {
            _quizService = quizService ?? throw new ArgumentNullException(nameof(quizService));
        }

        [HttpGet]
        public IActionResult List()
        {
            QuizListViewModel viewModel = _quizService.GetQuizzes();
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> QuizDetail(int id)
        {
            QuizDetailViewModel viewModel = await _quizService.GetQuizAsync(id);
            return View(viewModel);
        }

        [HttpGet]
        [Authorize(Roles = RoleNames.EDIT)]
        public IActionResult CreateQuiz()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = RoleNames.EDIT)]
        public async Task<IActionResult> CreateQuiz(CreateQuizViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                int quizId = await _quizService.CreateQuizAsync(viewModel);
                return RedirectToAction(nameof(CreateQuestion), new { quizId = quizId });
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        [Authorize(Roles = RoleNames.EDIT)]
        public IActionResult CreateQuestion(int quizId)
        {
            var viewModel = new CreateQuestionViewModel()
            {
                QuizId = quizId
            };

            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleNames.EDIT)]
        public async Task<IActionResult> CreateQuestion(CreateQuestionViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _quizService.CreateQuestionAsync(viewModel);
                return RedirectToAction(nameof(QuizDetail), new { Id = viewModel.QuizId });
            }
            else
            {
                return View(viewModel);
            }
        }

        [HttpGet]
        [Authorize(Roles = RoleNames.EDIT)]
        public IActionResult EditQuestion(int quizId, int questionId)
        {
            var viewModel = new EditQuestionViewModel()
            {
                QuizId = quizId,
                QuestionId = questionId
            };

            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleNames.EDIT)]
        public async Task<IActionResult> EditQuestion(EditQuestionViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _quizService.UpdateQuestionAsync(viewModel.QuestionId, viewModel.TitleUpdate);
                return RedirectToAction(nameof(QuizDetail), new { Id = viewModel.QuizId });
            }
            else
            {
                return View(viewModel);
            }
        }

        [HttpGet]
        [Authorize(Roles = RoleNames.EDIT)]
        public IActionResult CreateAnswer(int quizId, int questionId)
        {
            var viewModel = new CreateAnswerViewModel()
            {
                QuizId = quizId,
                QuestionId = questionId
            };

            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleNames.EDIT)]
        public async Task<IActionResult> CreateAnswer(CreateAnswerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _quizService.CreateAnswerAsync(viewModel.QuestionId, viewModel.Title);
                return RedirectToAction(nameof(QuizDetail), new { Id = viewModel.QuizId });
            }
            else
            {
                return View(viewModel);
            }
        }

        [HttpGet]
        [Authorize(Roles = RoleNames.EDIT)]
        public IActionResult EditAnswer(int quizId, int answerId)
        {
            var viewModel = new EditAnswerViewModel()
            {
                QuizId = quizId,
                AnswerId = answerId
            };

            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleNames.EDIT)]
        public async Task<IActionResult> EditAnswer(EditAnswerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _quizService.UpdateAnswerAsync(viewModel.AnswerId, viewModel.TitleUpdate);
                return RedirectToAction(nameof(QuizDetail), new { Id = viewModel.QuizId });
            }
            else
            {
                return View(viewModel);
            }
        }

        [HttpPost]
        [Authorize(Roles = RoleNames.EDIT)]
        public async Task<IActionResult> DeleteQuiz(int quizId)
        {
            await _quizService.DeleteQuizAsync(quizId);
            return RedirectToActionPermanent(actionName: nameof(Quiz.List), controllerName: nameof(Quiz));
        }

        [HttpPost]
        [Authorize(Roles = RoleNames.EDIT)]
        public async Task<IActionResult> DeleteQuestion(int quizId, int questionId)
        {
            await _quizService.DeleteQuestionAsync(questionId);
            return RedirectToAction(actionName: nameof(Quiz.QuizDetail), controllerName: nameof(Quiz), new {id = quizId });
        }

        [HttpPost]
        [Authorize(Roles = RoleNames.EDIT)]
        public async Task<IActionResult> DeleteAnswer(int quizId, int answerId)
        {
            await _quizService.DeleteAnswerAsync(answerId);
            return RedirectToAction(actionName: nameof(Quiz.QuizDetail), controllerName: nameof(Quiz), new { id = quizId });
        }

        [HttpPost]
        [Authorize(Roles = RoleNames.EDIT)]
        public async Task<IActionResult> ReorderQuestion(int quizId, int questionId, int position)
        {
            await _quizService.ReorderQuestionAsync(quizId, questionId, position);
            return RedirectToAction(actionName: nameof(Quiz.QuizDetail), controllerName: nameof(Quiz), new { id = quizId });
        }

    }
}

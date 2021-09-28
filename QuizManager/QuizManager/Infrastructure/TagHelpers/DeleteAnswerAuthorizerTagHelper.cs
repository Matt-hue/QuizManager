using Microsoft.AspNetCore.Razor.TagHelpers;
using QuizManager.EntityFramework.Models;
using QuizManager.Models.Quiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizManager.Infrastructure.TagHelpers
{
    [HtmlTargetElement(TAG, Attributes = "question-id")]
    public class DeleteAnswerAuthorizerTagHelper : TagHelper
    {
        private const string TAG = "delete-answer-authorizer";

        private readonly IQuizRepository _quizRepository;

        public DeleteAnswerAuthorizerTagHelper(IQuizRepository quizService)
        {
            _quizRepository = quizService ?? throw new ArgumentNullException(nameof(quizService));
        }

        [HtmlAttributeName("question-id")]
        public string QuestionId { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            Question question = await _quizRepository.GetQuestionAsync(Int32.Parse(QuestionId));

            if (question.Answers.Count() < 4)
            {
                output.SuppressOutput();
            }

        }
    }
}

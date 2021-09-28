using QuizManager.Models.Quiz;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace QuizManager.Infrastructure.Validation
{
    public class AnswerListSizeValidationAttribute : ValidationAttribute
    {
        public AnswerListSizeValidationAttribute(int minAnswerListSize, int maxAnswerListSize)
        {
            Min = minAnswerListSize;
            Max = maxAnswerListSize;
        }
        public int Min { get; }
        public int Max { get; }

        public string GetErrorMessage() =>
                            $"Questions must contain between {Min} & {Max} answers.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var viewModel = (CreateQuestionViewModel)validationContext.ObjectInstance;


            int validAnswers = 0;

            PropertyInfo[] properties = typeof(CreateQuestionViewModel).GetProperties();
            foreach (var p in properties)
            {
                if (p.PropertyType == typeof(string) && p.Name.Contains("Answer"))
                {
                    var answer = (string)p.GetValue(viewModel);
                    if (!string.IsNullOrWhiteSpace(answer))
                    {
                        validAnswers++;
                    }
                }
            }

            if (validAnswers <= Max && validAnswers >= Min)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(GetErrorMessage());
            }
        }
    }
}

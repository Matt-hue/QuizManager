using Moq;
using QuizManager.EntityFramework.Models;
using QuizManager.Models.Quiz;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace QuizManager.Tests.ServiceTests
{
    public class QuizServiceTests
    {
        private Mock<IQuizRepository> _mockQuizRepository { get; set; }
        private IQuizService _quizServiceStub { get; set; }
        public QuizServiceTests()
        {
            this._mockQuizRepository = new Mock<IQuizRepository>();
            this._quizServiceStub = new QuizService(_mockQuizRepository.Object);
        }

        [Fact]
        public async void question_order_should_increase()
        {
            //Arrange

            var firstQ = new Question()
            {
                Id = 1,
                Title = "q1",
                Order = 0
            };

            var trackedQ = new Question()
            {
                Id = 2,
                Title = "track-me",
                Order = 1
            };

            var thirdQ = new Question()
            {
                Id = 3,
                Title = "q3",
                Order = 2
            };

            var fourthQ = new Question()
            {
                Id = 4,
                Title = "q4",
                Order = 3
            };

            var qList = new List<Question>() { firstQ, trackedQ, thirdQ, fourthQ };

            _mockQuizRepository
                .Setup(r => r.GetQuestionAsync(It.IsAny<int>()))
                .ReturnsAsync(trackedQ);

            _mockQuizRepository
                .Setup(r => r.GetAllQuestionsAsync(It.IsAny<int>()))
                .ReturnsAsync(qList);

            //Act
            await _quizServiceStub.ReorderQuestionAsync(It.IsAny<int>(), 2, 2);

            //Assert
            firstQ.Order.ShouldBe(0);
            trackedQ.Order.ShouldBe(2);
            thirdQ.Order.ShouldBe(1);
            fourthQ.Order.ShouldBe(3);
        }

        [Fact]
        public async void question_order_should_decrease()
        {
            //Arrange

            var firstQ = new Question()
            {
                Id = 1,
                Title = "q1",
                Order = 0
            };

            var trackedQ = new Question()
            {
                Id = 2,
                Title = "track-me",
                Order = 1
            };

            var thirdQ = new Question()
            {
                Id = 3,
                Title = "q3",
                Order = 2
            };

            var fourthQ = new Question()
            {
                Id = 4,
                Title = "q4",
                Order = 3
            };

            var qList = new List<Question>() {firstQ, trackedQ, thirdQ, fourthQ };

            _mockQuizRepository
                .Setup(r => r.GetQuestionAsync(It.IsAny<int>()))
                .ReturnsAsync(trackedQ);

            _mockQuizRepository
                .Setup(r => r.GetAllQuestionsAsync(It.IsAny<int>()))
                .ReturnsAsync(qList);

            //Act
            await _quizServiceStub.ReorderQuestionAsync(It.IsAny<int>(), 2, 0);

            //Assert
            firstQ.Order.ShouldBe(1);
            trackedQ.Order.ShouldBe(0);
            thirdQ.Order.ShouldBe(2);
            fourthQ.Order.ShouldBe(3);
        }


        [Fact]
        public async void question_order_should_not_decrease_if_question_is_first()
        {
            //Arrange

            var trackedQ = new Question()
            {
                Id = 1,
                Title = "track-me",
                Order = 0
            };

            var secondQ = new Question()
            {
                Id = 2,
                Title = "q2",
                Order = 1
            };

            var thirdQ = new Question()
            {
                Id = 3,
                Title = "q3",
                Order = 2
            };

            var fourthQ = new Question()
            {
                Id = 4,
                Title = "q4",
                Order = 3
            };

            var qList = new List<Question>() { trackedQ, secondQ, thirdQ, fourthQ };

            _mockQuizRepository
                .Setup(r => r.GetQuestionAsync(It.IsAny<int>()))
                .ReturnsAsync(trackedQ);

            _mockQuizRepository
                .Setup(r => r.GetAllQuestionsAsync(It.IsAny<int>()))
                .ReturnsAsync(qList);

            //Act
            await _quizServiceStub.ReorderQuestionAsync(It.IsAny<int>(), 2, 0);

            //Assert
            trackedQ.Order.ShouldBe(0);
            secondQ.Order.ShouldBe(1);
            thirdQ.Order.ShouldBe(2);
            fourthQ.Order.ShouldBe(3);
        }

        [Fact]
        public async void question_order_should_not_increase_if_question_is_last()
        {
            //Arrange

            var firstQ = new Question()
            {
                Id = 1,
                Title = "q1",
                Order = 0
            };

            var secondQ = new Question()
            {
                Id = 2,
                Title = "q2",
                Order = 1
            };

            var thirdQ = new Question()
            {
                Id = 3,
                Title = "q3",
                Order = 2
            };

            var trackedQ = new Question()
            {
                Id = 4,
                Title = "track-me",
                Order = 3
            };


            var qList = new List<Question>() { firstQ, trackedQ, secondQ, thirdQ };

            _mockQuizRepository
                .Setup(r => r.GetQuestionAsync(It.IsAny<int>()))
                .ReturnsAsync(trackedQ);

            _mockQuizRepository
                .Setup(r => r.GetAllQuestionsAsync(It.IsAny<int>()))
                .ReturnsAsync(qList);

            //Act
            await _quizServiceStub.ReorderQuestionAsync(It.IsAny<int>(), 2, 4);

            //Assert

            firstQ.Order.ShouldBe(0);
            secondQ.Order.ShouldBe(1);
            thirdQ.Order.ShouldBe(2);
            trackedQ.Order.ShouldBe(3);
        }
    }
}

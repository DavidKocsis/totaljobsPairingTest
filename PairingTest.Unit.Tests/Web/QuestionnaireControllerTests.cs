using System;
using System.Collections.Generic;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using PairingTest.Web.Controllers;
using PairingTest.Web.Models;
using PairingTest.Web.Proxies;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture]
    public class QuestionnaireControllerTests
    {
        [Test]
        public void ShouldGetQuestions()
        {
            //Arrange
            var expectedTitle = "My expected quesitons";
            var questionnaireApiProxy = Substitute.For<IQuestionnaireApiProxy>();
            questionnaireApiProxy.Get().Returns(new QuestionnaireViewModel
            {
                QuestionnaireTitle = expectedTitle,
                QuestionsText = new List<string> {"question1", "question2", "question3"}
            });

            var questionnaireController = new QuestionnaireController(questionnaireApiProxy);

            //Act
            var result = (QuestionnaireViewModel)questionnaireController.Index().Result.ViewData.Model;
            
            //Assert
            Assert.That(result.QuestionnaireTitle, Is.EqualTo(expectedTitle));
            Assert.That(result.QuestionsText[0], Is.EqualTo("question1"));
            Assert.That(result.QuestionsText[1], Is.EqualTo("question2"));
            Assert.That(result.QuestionsText[2], Is.EqualTo("question3"));
        }

        [Test]
        public void ShouldHandleEmptyResponses()
        {
            var questionnaireApiProxy = Substitute.For<IQuestionnaireApiProxy>();
            questionnaireApiProxy.Get().Returns(new QuestionnaireViewModel());
            var questionnaireController = new QuestionnaireController(questionnaireApiProxy);

            var result = (QuestionnaireViewModel)questionnaireController.Index().Result.ViewData.Model;
            Assert.That(result.Status, Is.EqualTo(ResponseStatus.NoQuestions));
        }

        [Test]
        public void shouldHandleExpections()
        {
            var questionnaireApiProxy = Substitute.For<IQuestionnaireApiProxy>();
            questionnaireApiProxy.Get().Throws(new Exception());
            var questionnaireController = new QuestionnaireController(questionnaireApiProxy);

            var result = (QuestionnaireViewModel)questionnaireController.Index().Result.ViewData.Model;
            Assert.That(result.Status, Is.EqualTo(ResponseStatus.ApiError));
        }
    }
}
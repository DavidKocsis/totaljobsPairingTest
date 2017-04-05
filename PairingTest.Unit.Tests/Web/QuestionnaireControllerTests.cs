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
            var questionnaireController = new QuestionnaireController(new QuestionnaireApiProxy());

            //Act
            var result = (QuestionnaireViewModel)questionnaireController.Index().ViewData.Model;
            
            //Assert
            Assert.That(result.QuestionnaireTitle, Is.EqualTo(expectedTitle));
            Assert.That(result.QuestionsText[0], Is.EqualTo("question1"));
            Assert.That(result.QuestionsText[1], Is.EqualTo("question2"));
            Assert.That(result.QuestionsText[2], Is.EqualTo("question3"));
        }


    }
}
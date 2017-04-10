using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using PairingTest.Web.Models;
using PairingTest.Web.Proxies;

namespace PairingTest.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
        private readonly IQuestionnaireApiProxy questionnaireApiProxy;

        public QuestionnaireController(IQuestionnaireApiProxy questionnaireApiProxy)
        {
            this.questionnaireApiProxy = questionnaireApiProxy;
        }


        public async Task<ViewResult> Index()
        {
            try
            {
                var result = await this.questionnaireApiProxy.Get();
                if (result.QuestionsText == null)
                {
                    result.Status = ResponseStatus.NoQuestions;
                }
                return View(result);
            }
            catch (Exception e)
            {
                return View(new QuestionnaireViewModel {Status = ResponseStatus.ApiError});
            }
        }

        public ActionResult SubmitAnswer(QuestionnaireViewModel model)
        {
            return View(model);
        }
    }
}

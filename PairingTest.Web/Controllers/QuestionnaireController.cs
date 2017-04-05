using System.Collections.Generic;
using System.Web.Mvc;
using PairingTest.Web.Models;
using PairingTest.Web.Proxies;

namespace PairingTest.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
          /* ASYNC ACTION METHOD... IF REQUIRED... */
//        public async Task<ViewResult> Index()
//        {
//        }

        private IQuestionnaireApiProxy questionnaireApiProxy;

        public QuestionnaireController(IQuestionnaireApiProxy questionnaireApiProxy)
        {
            this.questionnaireApiProxy = questionnaireApiProxy;
        }

           
        public ViewResult Index()
        {
            return View(this.questionnaireApiProxy.Get());
        }
    }
}

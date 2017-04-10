using System.Net.Http;
using System.Threading.Tasks;
using PairingTest.Web.Models;

namespace PairingTest.Web.Proxies
{
    public interface IQuestionnaireApiProxy
    {
        Task<QuestionnaireViewModel> Get();
    }
}
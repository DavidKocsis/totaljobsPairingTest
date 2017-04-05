using System.Net.Http;
using System.Threading.Tasks;

namespace PairingTest.Web.Proxies
{
    public interface IQuestionnaireApiProxy
    {
        Task<HttpResponseMessage> Get();
    }
}
using System.Net.Http;

namespace PairingTest.Web.Proxies
{
    public interface IHttpClientFactory
    {
        HttpClient CreateHttpClient();
    }
}

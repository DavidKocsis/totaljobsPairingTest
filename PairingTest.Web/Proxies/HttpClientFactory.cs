
using System.Net.Http;

namespace PairingTest.Web.Proxies
{
    public class HttpClientFactory : IHttpClientFactory
    {
        private readonly HttpMessageHandler messageHandler;

        public HttpClientFactory(HttpMessageHandler messageHandler)
        {
            this.messageHandler = messageHandler;
        }

        public HttpClientFactory()
        {
            this.messageHandler = null;
        }

        public HttpClient CreateHttpClient()
        {
            return this.messageHandler != null ? new HttpClient(this.messageHandler) : new HttpClient();
        }
    }
}
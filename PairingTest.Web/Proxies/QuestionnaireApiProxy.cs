
using System;
using PairingTest.Web.Models;
using System.Net.Http;
using System.Threading.Tasks;
using PairingTest.Web.Configs;

namespace PairingTest.Web.Proxies
{
    public class QuestionnaireApiProxy : IQuestionnaireApiProxy
    {
        private readonly HttpClient client;
        private readonly IQuestionnaireApiConfig config;

        public QuestionnaireApiProxy(IHttpClientFactory clientFactory, IQuestionnaireApiConfig config)
        {
            this.config = config;
            this.client = clientFactory.CreateHttpClient();
            this.client.BaseAddress = new Uri(config.BaseUrl);
        }

        public async Task<QuestionnaireViewModel> Get()
        {
            var response = await client.GetAsync(config.Endpoint);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<QuestionnaireViewModel>();
            }
            return new QuestionnaireViewModel { Status = ResponseStatus.ApiError };
        }
    }
}
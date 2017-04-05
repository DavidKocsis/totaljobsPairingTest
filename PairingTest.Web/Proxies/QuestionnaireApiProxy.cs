
using System;
using System.Collections.Generic;
using PairingTest.Web.Models;

using System.Net.Http;
using System.Threading.Tasks;

namespace PairingTest.Web.Proxies
{
    public class QuestionnaireApiProxy : IQuestionnaireApiProxy
    {
        public Task<HttpResponseMessage> Get()
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:50014/");

            return client.GetAsync("/api/questions");
        }
    }
}
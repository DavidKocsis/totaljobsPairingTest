
using System;
using System.Net;
using System.Net.Http;
using NSubstitute;
using NUnit.Framework;
using PairingTest.Unit.Tests.Helpers;
using PairingTest.Web.Configs;
using PairingTest.Web.Models;
using PairingTest.Web.Proxies;

namespace PairingTest.Unit.Tests.Web
{
    public class QuestionnaireApiProxyTests
    {
        [Test]
        public async void ShouldHandleApiErrors()
        {
            var fakeResponseHandLer = new FakeResponseHandLer();
            fakeResponseHandLer.AddFakeResponse(new Uri("https://localhost/test/questions"), new HttpResponseMessage(HttpStatusCode.InternalServerError));

            var mockHttpClient = new HttpClientFactory(fakeResponseHandLer);
            var config = new QuestionnaireApiConfig {BaseUrl = "http://localhost",Endpoint = "/test/questions"};
            var sut = new QuestionnaireApiProxy(mockHttpClient,config);
            var result = await sut.Get();
            Assert.AreEqual(result.Status, ResponseStatus.ApiError);
        }
    }
}

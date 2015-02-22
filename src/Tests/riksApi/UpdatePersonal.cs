using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using NUnit.Framework;
using Owin;
using Risk.Api;
using Risk.Api.Adpaters;

namespace Tests.riksApi
{
    [TestFixture]
    public class UpdatePersonal
    {
        private HttpClient _client;
        private IDisposable _website;

        [Test]
        public void should_validate_when_firstName_is_empty()
        {
            SetUpOwinHost();
            var peronalDetails = new
            {
                firstName = "",
                surname = "smith"
            };
            
            var riskId = Guid.NewGuid();
            var requestUri = string.Format("api/risk/{0}/sections/personal", riskId);
            var response =  _client.PostAsJsonAsync(requestUri, peronalDetails).Result;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            var result = response.Content.ReadAsStringAsync().Result;
        }

        private void SetUpOwinHost()
        {
            var hostUri = new Uri("http://localhost:30415");
            _website = WebApp.Start(hostUri.ToString(), StartUp);
            _client = new HttpClient {BaseAddress = hostUri};
        }

        private void StartUp(IAppBuilder appBuilder)
        {
            var httpConfig = new HttpConfiguration();
            var container = new BootStrapper(new InMemoryAdapters())
                .Boot(httpConfig);
            appBuilder.UseWebApi(httpConfig);
        }
    }
}

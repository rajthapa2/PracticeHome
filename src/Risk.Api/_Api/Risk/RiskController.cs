using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Risk.Api._Api.Risk
{
    public class RiskController : ApiController
    {
        [Route("api/risk")]
        public HttpResponseMessage Post([FromBody] CreateRiskWithRedirect body)
        {
            Request.Content.ReadAsStringAsync();
            var result = new
            {
                id = Guid.NewGuid(),
                redirect = body.Redirect
            };
            return Request.CreateResponse(HttpStatusCode.Created, result);
        }
    }

    public class CreateRiskWithRedirect 
    {
        public string Redirect { get; set; }
    }
}

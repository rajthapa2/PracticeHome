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
            var id = Guid.NewGuid();
            return Request.Redirect(new Uri(body.Redirect + id));
        }
    }

    public class CreateRiskWithRedirect 
    {
        public string Redirect { get; set; }
    }
}

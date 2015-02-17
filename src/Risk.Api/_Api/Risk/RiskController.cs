using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Pipeline;

namespace Risk.Api._Api.Risk
{
    public class RiskController : ApiController
    {
        private readonly IPipeLine _pipeline;

        public RiskController(IPipeLine pipeline)
        {
            _pipeline = pipeline;
        }

        [Route("api/risk")]
        public HttpResponseMessage Post([FromBody] CreateRiskWithRedirect body)
        {
            var createRisk = new CreateRisk {RiskId = Guid.NewGuid()};

            _pipeline.Send(createRisk);
            var id = Guid.NewGuid();
            return Request.Redirect(new Uri(body.Redirect + id));
        }
    }

    public class CreateRiskWithRedirect 
    {
        public string Redirect { get; set; }
    }
}

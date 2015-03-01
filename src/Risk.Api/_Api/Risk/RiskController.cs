using System;
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
            var id = Guid.NewGuid();
            var createRisk = new CreateRisk {RiskId = id};

            _pipeline.Send(createRisk);

            return Request.Redirect(new Uri(body.Redirect + id));
        }
    }

    public class CreateRiskWithRedirect 
    {
        public string Redirect { get; set; }
    }
}

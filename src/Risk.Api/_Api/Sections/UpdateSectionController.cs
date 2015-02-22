using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Pipeline;
using Risk.Api._Api.Personal;

namespace Risk.Api._Api.Sections
{
    public class UpdateSectionController :ApiController
    {
        private readonly IPipeLine _pipeline;

        public UpdateSectionController(IPipeLine pipeline)
        {
            _pipeline = pipeline;
        }

        [Route("api/risk/{riskId}/sections/{section}")]
        public HttpResponseMessage Post([FromUri] Guid riskId)
        {
            var json = Request.Content.ReadAsStringAsync().Result;
            var command = JsonConvert.DeserializeObject<UpdatePersonal>(json);

            _pipeline.Send(command);

            return Request.CreateResponse(HttpStatusCode.Accepted, new { RiskId = riskId });
        }
    }
}

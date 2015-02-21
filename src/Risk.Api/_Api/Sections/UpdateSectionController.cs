using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Risk.Api._Api.Sections
{
    public class UpdateSectionController :ApiController
    {
        [Route("api/risk/{riskId}/sections/{section}")]
        public HttpResponseMessage Post([FromUri] Guid riskId)
        {
            return Request.CreateResponse(HttpStatusCode.Accepted, new { RiskId = riskId });
        }
    }
}

using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Risk.Api._Api.Risk
{
    public class RiskController : ApiController
    {
        [Route("api/risk")]
        public HttpResponseMessage Post()
        {
            var result = Guid.NewGuid();
            //return Request.CreateResponse(HttpStatusCode.Created, result);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}

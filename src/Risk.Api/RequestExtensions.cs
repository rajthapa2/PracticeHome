using System;
using System.Net;
using System.Net.Http;

namespace Risk.Api
{
    public static class RequestExtensions
    {
        public static HttpResponseMessage Redirect(this HttpRequestMessage httpRequest, Uri redirect)
        {
            var response = httpRequest.CreateResponse(HttpStatusCode.Moved);
            response.Headers.Location = redirect;
            return response;
        }
    }
}

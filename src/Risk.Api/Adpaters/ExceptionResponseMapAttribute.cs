using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using Pipeline;

namespace Risk.Api.Adpaters
{
    public class ExceptionResponseMapAttribute  : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var exception = context.Exception;
            context.Response = context.Request.CreateResponse(HttpStatusCode.BadRequest,
                (exception as IExceptionValidation).Value);
        }
    }
}

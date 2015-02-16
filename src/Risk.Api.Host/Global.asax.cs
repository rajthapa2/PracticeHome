using System.Web;
using System.Web.Http;
using Risk.Api.Adpaters;

namespace Risk.Api.Host
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            new BootStrapper(new RealAdapters())
                .Boot(GlobalConfiguration.Configuration);
        }
    }
}
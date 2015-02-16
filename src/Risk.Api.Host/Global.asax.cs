using System;
using System.Web.Http;
using Risk.Api.Adpaters;

namespace Risk.Api.Host
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            new BootStrapper(new RealAdapters())
                .Boot(GlobalConfiguration.Configuration);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
using System.Web.Mvc;

namespace RiskCapture.Client.Controllers
{
    public class PagesController : Controller
    {
        //
        // GET: /Pages/

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Questions()
        {
            return View();
        }

    }
}

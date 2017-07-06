using System.Web.Mvc;

namespace MultiPageProject.Web.Controllers
{
    public class AboutController : MultiPageProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
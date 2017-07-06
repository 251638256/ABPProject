using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace MultiPageProject.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : MultiPageProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
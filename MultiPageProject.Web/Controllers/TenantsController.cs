using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using MultiPageProject.Authorization;
using MultiPageProject.MultiTenancy;

namespace MultiPageProject.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : MultiPageProjectControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public ActionResult Index()
        {
            var output = _tenantAppService.GetTenants();
            return View(output);
        }
    }
}
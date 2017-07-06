using Abp.Authorization;
using MultiPageProject.Authorization.Roles;
using MultiPageProject.MultiTenancy;
using MultiPageProject.Users;

namespace MultiPageProject.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}

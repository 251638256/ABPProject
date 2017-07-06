using System;
using System.Collections.Generic;
using Abp.Authorization;
using Abp.MultiTenancy;

namespace MultiPageProject {
    public class MyAuthorizationProvider : AuthorizationProvider {

        public override void SetPermissions(IPermissionDefinitionContext context) {
            var administration = context.CreatePermission("Administration");

            var userManagement = administration.CreateChildPermission("Administration.UserManagement");
            userManagement.CreateChildPermission("Administration.UserManagement.CreateUser");

            var roleManagement = administration.CreateChildPermission("Administration.RoleManagement");
        }
    }
}
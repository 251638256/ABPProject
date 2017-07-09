using System;
using System.Collections.Generic;
using Abp.Authorization;
using Abp.MultiTenancy;
using MultiPageProject.Authorization;

namespace MultiPageProject {
    public class MyAuthorizationProvider : AuthorizationProvider {

        public override void SetPermissions(IPermissionDefinitionContext context) {

            context.CreatePermission(PermissionNames.A);
            context.CreatePermission(PermissionNames.B);
            context.CreatePermission(PermissionNames.C);
            context.CreatePermission(PermissionNames.D);

            //var userManagement = administration.CreateChildPermission("Administration.UserManagement");
            //userManagement.CreateChildPermission("Administration.UserManagement.CreateUser");

            //var roleManagement = administration.CreateChildPermission("Administration.RoleManagement");
        }
    }
}
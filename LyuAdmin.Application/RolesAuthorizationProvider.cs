using Abp.Authorization;
using Abp.Localization;
using LyuAdmin.Roles;

namespace LyuAdmin
{
    public class RolesAuthorizationProvider: AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            var role = context.CreatePermission(RolesPermissions.Role, new LocalizableString("Role", ""));
            //var role = context.CreateChildPermission(RolesPermissions.Role, L("Role"));
             role.CreateChildPermission(RolesPermissions.Role_CreateRole, new LocalizableString("CreateRole", ""));
            // role.CreateChildPermission(RolesPermissions.Role_UpdateRole, L("UpdateRole"));
            // role.CreateChildPermission(RolesPermissions.Role_DeleteRole, L("DeleteRole"));
        }
    }
}
using Abp.Authorization;
using Abp.Localization;
using LyuAdmin.Authorization.Roles;

namespace LyuAdmin
{
    public class AppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            var pages = context.CreatePermission(Permissions.Pages, new LocalizableString("Pages", LyuAdminConsts.PermissionsSourceName));
            var pageAdmin = pages.CreateChildPermission(Permissions.Pages_Administration, new LocalizableString("PagesAdministration", LyuAdminConsts.PermissionsSourceName));

            var role = pageAdmin.CreateChildPermission(RolesPermissions.Role, new LocalizableString("Role", LyuAdminConsts.PermissionsSourceName));
            role.CreateChildPermission(RolesPermissions.Role_CreateRole, new LocalizableString("CreateRole", LyuAdminConsts.PermissionsSourceName));
            role.CreateChildPermission(RolesPermissions.Role_UpdateRole, new LocalizableString("UpdateRole", LyuAdminConsts.PermissionsSourceName));
            role.CreateChildPermission(RolesPermissions.Role_DeleteRole, new LocalizableString("DeleteRole", LyuAdminConsts.PermissionsSourceName));
        }
    }
}
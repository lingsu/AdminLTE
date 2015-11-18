
namespace LyuAdmin.Roles
{
    public partial class RolesPermissions
    {
        //TODO:★请将以下内容剪切到RolesPermissions.cs

        /// <summary>
        /// 角色管理管理权限
        /// </summary>
        public const string Role = "Roles.Role";
        public const string Role_CreateRole = "Roles.Role.CreateRole";
        public const string Role_UpdateRole = "Roles.Role.UpdateRole";
        public const string Role_DeleteRole = "Roles.Role.DeleteRole";

    }
}

//TODO:★请将以下内容剪切到RolesAuthorizationProvider.cs
/*
            //角色管理管理
            var role = module.CreateChildPermission(RolesPermissions.Role, L("Role"));
            role.CreateChildPermission(RolesPermissions.Role_CreateRole, L("CreateRole"));
            role.CreateChildPermission(RolesPermissions.Role_UpdateRole, L("UpdateRole"));
            role.CreateChildPermission(RolesPermissions.Role_DeleteRole, L("DeleteRole"));

*/

//TODO:★请将以下内容剪切到Web站点Permissions.xml
/*
    <!-- 角色管理管理 -->
    <text name="Role" value="角色管理管理" />
    <text name="CreateRole" value="新增角色管理" />
    <text name="UpdateRole" value="更新角色管理" />
    <text name="DeleteRole" value="删除角色管理" />

*/


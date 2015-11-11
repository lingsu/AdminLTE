using Abp.Authorization.Roles;
using LyuAdmin.MultiTenancy;
using LyuAdmin.Users;

namespace LyuAdmin.Authorization.Roles
{
    public class Role : AbpRole<Tenant, User>
    {

    }
}
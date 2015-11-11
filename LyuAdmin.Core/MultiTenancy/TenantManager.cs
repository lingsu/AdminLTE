using Abp.MultiTenancy;
using LyuAdmin.Authorization.Roles;
using LyuAdmin.Editions;
using LyuAdmin.Users;

namespace LyuAdmin.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, Role, User>
    {
        public TenantManager(EditionManager editionManager)
            : base(editionManager)
        {

        }
    }
}
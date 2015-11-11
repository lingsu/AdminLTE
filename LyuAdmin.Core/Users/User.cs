using System;
using Abp.Authorization.Users;
using Abp.Extensions;
using LyuAdmin.MultiTenancy;

namespace LyuAdmin.Users
{
    public class User : AbpUser<Tenant, User>
    {
        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }
    }
}
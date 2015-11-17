using Abp.AutoMapper;
using LyuAdmin.Authorization.Roles;

namespace LyuAdmin.Roles.Dto
{
    [AutoMap(typeof(Role))]
    public class RoleDto
    {
        public virtual string Name { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual bool IsDefault { get; set; }
    }
}
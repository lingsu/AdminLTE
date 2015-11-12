using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using LyuAdmin.Authorization.Roles;

namespace LyuAdmin.Roles.Dto
{
    [AutoMapFrom(typeof(Role))]
    public class RoleQueryDto:EntityDto
    {
        public string Name { get; set; }
    }
}
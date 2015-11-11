using System.Threading.Tasks;
using Abp.Application.Services;
using LyuAdmin.Users.Dto;

namespace LyuAdmin.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task ProhibitPermission(ProhibitPermissionInput input);

        Task RemoveFromRole(long userId, string roleName);
    }
}
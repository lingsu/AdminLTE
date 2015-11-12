using System.Threading.Tasks;
using Abp.Application.Services;
using Lyu.Utility.Application.Services.Dto;
using LyuAdmin.Users.Dto;

namespace LyuAdmin.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task ProhibitPermission(ProhibitPermissionInput input);

        Task RemoveFromRole(long userId, string roleName);
        Task<QueryResultOutput<UserQueryDto>> GetQueryUser(GetQueryUserInput input);
    }
}
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Lyu.Utility.Application.Services.Dto;
using Lyu.Utility.Application.Services.Dto.Extensions;
using LyuAdmin.Users.Dto;

namespace LyuAdmin.Users
{
    /* THIS IS JUST A SAMPLE. */
    public class UserAppService : LyuAdminAppServiceBase, IUserAppService
    {
        private readonly UserManager _userManager;
        private readonly IPermissionManager _permissionManager;

        public UserAppService(UserManager userManager, IPermissionManager permissionManager)
        {
            _userManager = userManager;
            _permissionManager = permissionManager;
        }

        public async Task ProhibitPermission(ProhibitPermissionInput input)
        {
            var user = await _userManager.GetUserByIdAsync(input.UserId);
            var permission = _permissionManager.GetPermission(input.PermissionName);
            //_userManager.Users.To<User>()
            await _userManager.ProhibitPermissionAsync(user, permission);
        }

        //Example for primitive method parameters.
        public async Task RemoveFromRole(long userId, string roleName)
        {
           
            CheckErrors(await _userManager.RemoveFromRoleAsync(userId, roleName));
        }

        public async Task<QueryResultOutput<UserQueryDto>> GetQueryUser(GetQueryUserInput input)
        {
            var result = await _userManager.Users
                .WhereIf(!input.Search.Value.IsNullOrWhiteSpace(),x=>x.UserName.Contains(input.Search.Value))
                .ToOutputAsync<UserQueryDto>(input);
            
            return result;
        } 
    }
}
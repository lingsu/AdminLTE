using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Lyu.Utility.Application.Services.Dto;
using Lyu.Utility.Application.Services.Dto.Extensions;
using Lyu.Utility.Extensions;
using LyuAdmin.Authorization.Roles;
using LyuAdmin.Roles.Dto;
using LyuAdmin.Users.Dto;
using Microsoft.AspNet.Identity;

namespace LyuAdmin.Users
{
    /* THIS IS JUST A SAMPLE. */
    public class UserAppService : LyuAdminAppServiceBase, IUserAppService
    {
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly IPermissionManager _permissionManager;
        private readonly IRepository<UserRole,long> _userRoleRepository;

        public UserAppService(UserManager userManager, RoleManager roleManager, IPermissionManager permissionManager, IRepository<UserRole, long> userRoleRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _permissionManager = permissionManager;
            _userRoleRepository = userRoleRepository;
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
                .WhereIf(!input.Search.Value.IsNullOrWhiteSpace(), x => x.UserName.Contains(input.Search.Value))
                .OrderByDescending(x => x.CreationTime)
               .ToOutputAsync<UserQueryDto>(input);
            foreach (var userQueryDto in result.Data)
            {
                //_roleManager.r
                userQueryDto.Roles = await (from userRole in _userRoleRepository.GetAll()
                    join role in _roleManager.Roles on userRole.RoleId equals role.Id
                    where userRole.UserId == userQueryDto.Id
                    select role).To<RoleQueryDto>().ToListAsync();
            }

             return result;
        }

        public async Task<UserDto> GetUser(long id)
        {
            var entity = await _userManager.GetUserByIdAsync(id);
            return entity.MapTo<UserDto>();
        }
    }
}
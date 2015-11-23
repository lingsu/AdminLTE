using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.UI;
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

        #region �û�����

        /// <summary>
        /// ���ݲ�ѯ������ȡ�û���ҳ�б�
        /// </summary>
        public async Task<QueryResultOutput<UserQueryDto>> GetUserQuery(GetUserQueryInput input)
        {

            var result = await _userManager.Users
                .WhereIf(!input.Search.Value.IsNullOrWhiteSpace(), x => x.UserName.Contains(input.Search.Value))
                .OrderByDescending(x => x.CreationTime)
               .ToOutputAsync<UserQueryDto>(input);
            foreach (var userQueryDto in result.Data)
            {
                userQueryDto.Roles = await (from userRole in _userRoleRepository.GetAll()
                                            join role in _roleManager.Roles on userRole.RoleId equals role.Id
                                            where userRole.UserId == userQueryDto.Id
                                            select role).To<RoleQueryDto>().ToListAsync();
            }

            return result;
        }
      

        /// <summary>
        /// ��ȡָ��id���û���Ϣ
        /// </summary>
        public async Task<UserDto> GetUser(long id)
        {
            var entity = await _userManager.GetUserByIdAsync(id);
            var dto = entity.MapTo<UserDto>();
            dto.AssignedRoleNames = await _userManager.GetRolesAsync(id);
            return dto;
        }

        /// <summary>
        /// ����������û�
        /// </summary>
        public async Task CreateOrUpdateUser(UserDto input)
        {
            if (input.Id == 0)
            {
                await CreateUser(input);
            }
            else
            {
                await UpdateUser(input);
            }
        }

        /// <summary>
        /// �����û�
        /// </summary>
        [AbpAuthorize(UsersPermissions.User_CreateUser)]
        public  async Task CreateUser(UserDto input)
        {
            //if (await _userManager(input.CategoryName))
            //{
            //    throw new UserFriendlyException(L("NameIsExists"));
            //}
            var entity = await _userManager.CreateAsync(input.MapTo<User>());
            if (!entity.Succeeded)
            {
                throw new UserFriendlyException(entity.Errors.First());
            }
        }

        /// <summary>
        /// �����û�
        /// </summary>
        [AbpAuthorize(UsersPermissions.User_UpdateUser)]
        public virtual async Task UpdateUser(UserDto input)
        {
            //if (await _userRepository.IsExistsUserByName(input.CategoryName, input.Id))
            //{
            //    throw new UserFriendlyException(L("NameIsExists"));
            //}
            var entity = await _userManager.GetUserByIdAsync(input.Id);
            await _userManager.UpdateAsync(input.MapTo(entity));
        }

        /// <summary>
        /// ɾ���û�
        /// </summary>
        [AbpAuthorize(UsersPermissions.User_DeleteUser)]
        public async Task DeleteUser(EntityRequestInput<long> input)
        {
            //TODO:ɾ��ǰ���߼��жϣ��Ƿ�����ɾ��
            var user = await _userManager.GetUserByIdAsync(input.Id);
            await _userManager.DeleteAsync(user);
        }

        /// <summary>
        /// ����ɾ���û�
        /// </summary>
        [AbpAuthorize(UsersPermissions.User_DeleteUser)]
        public async Task BatchDeleteUser(IEnumerable<int> input)
        {
            //TODO:����ɾ��ǰ���߼��жϣ��Ƿ�����ɾ��
            foreach (var i in input)
            {
                var user = await _userManager.GetUserByIdAsync(i);
                await _userManager.DeleteAsync(user);
            }
        }

        #endregion
    }
}
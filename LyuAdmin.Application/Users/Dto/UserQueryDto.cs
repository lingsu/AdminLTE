using System;
using System.Collections.Generic;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using LyuAdmin.Roles.Dto;

namespace LyuAdmin.Users.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserQueryDto : Entity<long>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public ICollection<RoleQueryDto> Roles { get; set; }
    }
}
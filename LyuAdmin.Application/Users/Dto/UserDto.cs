using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Abp.Domain.Entities;

namespace LyuAdmin.Users.Dto
{
    [AutoMap(typeof(User))]
    public class UserDto : Entity<long>
    {
        [Required]
        public string Name { get; set; }
        [StringLength(32)]
        [Required]
        public string Surname { get; set; }

        [StringLength(32)]
        [Required]
        public string UserName { get; set; }

        [StringLength(32,MinimumLength = 6)]
        [DisplayName("密码")]
        public string Password { get; set; }
        [Compare("Password")]
        [StringLength(32, MinimumLength = 6)]
        [DisplayName("密码 (核对)")]
        public string PasswordRepeat { get; set; }
        [Required]
        [StringLength(256)]
        public string EmailAddress { get; set; }

        public bool IsEmailConfirmed { get; set; }
        [DisplayName("下次登录需要修改密码")]
        public bool ShouldChangePasswordOnNextLogin { get; set; }
        [DisplayName("发送激活邮件")]
        public string SendActivationEmail { get; set; }
        public string EmailConfirmationCode { get; set; }
        [DisplayName("激活")]
        public bool IsActive { get; set; }
        [DisplayName("使用随机密码")]
        public bool SetRandomPassword { get; set; }
        public IList<string> AssignedRoleNames { get; set; }

    }
}
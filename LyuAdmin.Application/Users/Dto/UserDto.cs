using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Abp.Domain.Entities;

namespace LyuAdmin.Users.Dto
{
    [AutoMap(typeof(User))]
    public class UserDto:Entity<long>
    {
        [Required]
        public string Name { get; set; }
        [StringLength(32)]
        [Required]
        public  string Surname { get; set; }

        [StringLength(32)]
        [Required]
        public virtual string UserName { get; set; }

        [Required]
        [StringLength(128)]
        public virtual string Password { get; set; }
        [Required]
        [StringLength(256)]
        public virtual string EmailAddress { get; set; }

        public virtual bool IsEmailConfirmed { get; set; }
        public virtual string EmailConfirmationCode { get; set; }
        public virtual bool IsActive { get; set; }

    }
}
using System.Collections.Generic;

namespace LyuAdmin.Users.Dto
{
    public class CreateOrUpdateUserInput
    {
        public UserDto User { get; set; }
        public IEnumerable<string> AssignedRoleNames { get; set; }
        public bool SendActivationEmail { get; set; }
    }
}
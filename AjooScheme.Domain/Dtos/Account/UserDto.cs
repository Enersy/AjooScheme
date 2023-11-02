using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjooScheme.Domain.Dtos.Account
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool LockoutEnabled { get; set; }
        public int PasswordTrail { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Explorer.Stakeholders.API.Enums.UserEnums;

namespace Explorer.Stakeholders.API.Dtos
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public UserRole Role { get; private set; }
        public bool IsActive { get; set; }
        public List<FollowerDto> Followers { get; private set; }
    }
}

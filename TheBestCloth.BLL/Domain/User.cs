using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using TheBestCloth.BLL.DTOs;

namespace TheBestCloth.BLL.Domain
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }

        public User() {}
        public User(RegisterUserDto registerUserDto)
        {
            Email = registerUserDto.Email;
            UserName = Email;
            FirstName = registerUserDto.FirstName;
            LastName = registerUserDto.LastName;
        }
    }
}

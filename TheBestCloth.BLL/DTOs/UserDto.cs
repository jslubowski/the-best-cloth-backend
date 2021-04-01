using System.Collections.Generic;
using TheBestCloth.BLL.Domain;

namespace TheBestCloth.BLL.DTOs
{
    public class UserDto
    {
        public int Id { get; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<string> UserRoles { get; set; }

        public UserDto(User user, ICollection<string> roles, string token) : this(user, roles)
        {
            Token = token;
        }

        public UserDto(User user, ICollection<string> roles)
        {
            Id = user.Id;
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserRoles = roles;
        }
    }
}

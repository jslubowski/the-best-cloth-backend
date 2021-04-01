using System.Collections.Generic;
using TheBestCloth.BLL.Domain;

namespace TheBestCloth.BLL.DTOs
{
    public class RegisterUserDto
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<string> UserRoles { get; set; }
    }
}

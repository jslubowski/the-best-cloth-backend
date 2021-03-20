using System.Security.Cryptography;
using System.Text;
using TheBestCloth.BLL.Domain;

namespace TheBestCloth.BLL.ModelDatabase
{
    public class User
    {
        public User() {}
        public User(RegisterUserDto registerUserDto)
        {
            using var hmac = new HMACSHA512();
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerUserDto.Password));
            PasswordSalt = hmac.Key;
            Email = registerUserDto.Email;
            FirstName = registerUserDto.FirstName;
            LastName = registerUserDto.LastName;
        }

        public int Id { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

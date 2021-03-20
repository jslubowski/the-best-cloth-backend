using TheBestCloth.BLL.ModelDatabase;

namespace TheBestCloth.BLL.Domain
{
    public class UserDto
    {
        public int Id { get; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserDto(User user, string token)
        {
            Id = user.Id;
            Token = token;
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
        }

        public UserDto(User user)
        {
            Id = user.Id;
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
        }
    }
}

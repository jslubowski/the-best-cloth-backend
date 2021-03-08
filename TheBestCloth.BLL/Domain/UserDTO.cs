namespace TheBestCloth.BLL.Domain
{
    public class UserDTO
    {
        public int Id { get; }
        public string Username { get; }
        public string Token { get; set; }
        public UserDTO(int id, string username)
        {
            Id = id;
            Username = username;
        }
        public UserDTO(int id, string username, string token)
        {
            Id = id;
            Username = username;
            Token = token;
        }
    }
}

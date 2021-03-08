using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TheBestCloth.API.Interfaces;
using TheBestCloth.BLL.Domain;
using TheBestCloth.BLL.Exceptions;
using TheBestCloth.BLL.Helpers;
using TheBestCloth.BLL.Interfaces;
using TheBestCloth.BLL.ModelDatabase;

namespace TheBestCloth.API.Service
{
    public class UserService : IUserService
    {
        public UserService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public async Task<UserDTO> RegisterUserAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            var existingUser = await _userRepository.GetUserByUsername(username);

            if (existingUser != null) throw new DatabaseException($"User {username} already exists!");

            using var hmac = new HMACSHA512();

            var user = new User
            {
                Username = username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key
            };

            var addedUser = await _userRepository.AddUserAsync(user);

            if (addedUser == null) throw new DatabaseException($"Error while adding user {username}");

            return new UserDTO(addedUser.Id, addedUser.Username, _tokenService.CreateToken(addedUser));
        }

        public Task<IEnumerable<User>> GetAllUsersAsync(PaginationParams paginationParams)
        {
            return _userRepository.GetAllUsersAsync(paginationParams);
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null) return null;
            return new UserDTO(user.Id, user.Username);
        }

        public async Task<UserDTO> GetUserByUsernameAsync(string username)
        {
            var user = await _userRepository.GetUserByUsername(username);
            if (user == null) return null;
            return new UserDTO(user.Id, user.Username);
        }

        public async Task<UserDTO> LoginUserAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUsername(username);

            if (user == null) return null;

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) 
                    throw new SecurityException($"Invalid password for user {user.Username}");

            }

            return new UserDTO(user.Id, user.Username, _tokenService.CreateToken(user));
        }
    }
}

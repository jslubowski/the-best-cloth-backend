using Microsoft.AspNetCore.Mvc;
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

        public async Task<UserDto> RegisterUserAsync([FromBody] RegisterUserDto registerUserDto)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(registerUserDto.Password);

            if (existingUser != null) throw new DatabaseException($"User {registerUserDto.Email} already exists!");

            var user = new User(registerUserDto);

            var addedUser = await _userRepository.AddUserAsync(user);

            if (addedUser == null) throw new DatabaseException($"Error while adding user {registerUserDto.Email}");

            return new UserDto(addedUser, _tokenService.CreateToken(addedUser));
        }

        public Task<IEnumerable<User>> GetAllUsersAsync(PaginationParams paginationParams)
        {
            return _userRepository.GetAllUsersAsync(paginationParams);
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return null;
            return new UserDto(user);
        }

        public async Task<UserDto> LoginUserAsync(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);

            if (user == null) return null;

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                    throw new SecurityException($"Invalid password for user {user.Email}");

            }

            return new UserDto(user, _tokenService.CreateToken(user));
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            return new UserDto(await _userRepository.GetUserByEmailAsync(email));
        }
    }
}

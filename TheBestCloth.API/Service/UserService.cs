using System;
using System.Linq;
using System.Security;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TheBestCloth.API.Interfaces;
using TheBestCloth.BLL.Domain;
using TheBestCloth.BLL.DTOs;
using TheBestCloth.BLL.Exceptions;
using TheBestCloth.BLL.Helpers;
using TheBestCloth.BLL.Interfaces;

namespace TheBestCloth.API.Service
{
    public class UserService : IUserService
    {
        public UserService(IUserRepository userRepository, ITokenService tokenService, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public async Task<UserDto> RegisterUserAsync([FromBody] RegisterUserDto registerUserDto)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(registerUserDto.Password);

            if (existingUser != null) throw new RegisterException($"User {registerUserDto.Email} already exists!");

            var result = await _userManager.CreateAsync(new User(registerUserDto), registerUserDto.Password);

            if (!result.Succeeded) throw new RegisterException(result.ToString());

            var user = await _userRepository.GetUserByEmailAsync(registerUserDto.Email);

            foreach (string role in registerUserDto.UserRoles)
            {
                await _userManager.AddToRoleAsync(user, role);
            }

            return new UserDto(user, registerUserDto.UserRoles, _tokenService.CreateToken(user, registerUserDto.UserRoles));
        }

        public Task<IEnumerable<User>> GetAllUsersAsync(PaginationParams paginationParams)
        {
            return _userRepository.GetAllUsersAsync(paginationParams);
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            var roles = await _userManager.GetRolesAsync(user);
            if (user == null) return null;
            return new UserDto(user, roles);
        }

        public async Task<UserDto> LoginUserAsync(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);

            var roles = await _userManager.GetRolesAsync(user);

            if (user == null) return null;

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, password, false);

            return result.Succeeded ? new UserDto(user, roles, _tokenService.CreateToken(user, roles)) : throw new SecurityException(result.ToString());
        }
    }
}

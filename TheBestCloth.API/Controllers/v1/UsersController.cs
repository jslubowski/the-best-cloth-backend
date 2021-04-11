using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security;
using System.Threading.Tasks;
using TheBestCloth.API.Interfaces;
using TheBestCloth.BLL.Domain;
using TheBestCloth.BLL.DTOs;
using TheBestCloth.BLL.Exceptions;

namespace TheBestCloth.API.Controllers.v1
{
    public class UsersController : BaseApiController
    {
        public UsersController(UserManager<User> userManager, SignInManager<User> signInManager,
            IUserService userService, IAuthenticationService authenticationService,
            ILogger<UsersController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
            _authenticationService = authenticationService;
            _logger = logger;
        }
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> RegisterAsync([FromBody] RegisterUserDto registerUserDto)
        {
            try
            {
                var user = await _userService.RegisterUserAsync(registerUserDto);
                if (user == null) return BadRequest();
                return Ok(user);
            }
            catch (RegisterException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(new ExceptionDto(ex.Message));
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> LoginAsync()
        {
            var credentials = _authenticationService.DecodeBasicAuthenticationHeader(
                HttpContext.Request.Headers["Authorization"]
                );
            if (credentials == null) return BadRequest("Incorrect format of authentication header");

            try
            {
                var user = await _userService.LoginUserAsync(credentials.Username, credentials.Password);

                if (user == null) return Unauthorized($"Can't find user {credentials.Username}");

                return Ok(user);
            }
            catch (SecurityException ex)
            {
                _logger.LogError(ex.ToString());
                return Unauthorized("Bad credentials");
            }
        }
    }
}

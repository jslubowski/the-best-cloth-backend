using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security;
using System.Threading.Tasks;
using TheBestCloth.API.Interfaces;
using TheBestCloth.BLL.Domain;
using TheBestCloth.BLL.Exceptions;

namespace TheBestCloth.API.Controllers.v1
{
    public class UsersController : BaseApiController
    {
        public UsersController(IUserService userService, IAuthenticationService authenticationService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _authenticationService = authenticationService;
            _logger = logger;
        }
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> RegisterAsync()
        {
            var credentials = _authenticationService.DecodeBasicAuthenticationHeader(
                this.HttpContext.Request.Headers["Authorization"]
                );
            if (credentials == null) return BadRequest("Incorrect format of authentication header");

            try
            {
                var user = await _userService.RegisterUserAsync(credentials.Username, credentials.Password);
                if (user == null) return BadRequest();
                return Ok(user);
            }
            catch (DatabaseException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(new ExceptionDTO(ex.Message));
            }            
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> LoginAsync()
        {
            var credentials = _authenticationService.DecodeBasicAuthenticationHeader(
                this.HttpContext.Request.Headers["Authorization"]
                );
            if (credentials == null) return BadRequest("Incorrect format of authentication header");

            try
            {
                var user = await _userService.LoginUserAsync(credentials.Username, credentials.Password);

                if (user == null) return Unauthorized($"Can't find user {credentials.Username}");

                return Ok(user);
            } catch (SecurityException ex)
            {
                _logger.LogError(ex.ToString());
                return Unauthorized("Invalid password!");
            }
        }
    }
}

using System.Threading.Tasks;
using TheBestCloth.BLL.Domain;
using TheBestCloth.BLL.DTOs;
using TheBestCloth.BLL.Helpers;

namespace TheBestCloth.API.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> RegisterUserAsync(RegisterUserDto registerUserDto);
        Task<IEnumerable<User>> GetAllUsersAsync(PaginationParams paginationParams);
        Task<UserDto> GetUserByIdAsync(int id);
        Task<UserDto> LoginUserAsync(string username, string password);
    }
}

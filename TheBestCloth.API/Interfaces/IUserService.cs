using System.Threading.Tasks;
using TheBestCloth.BLL.Domain;
using TheBestCloth.BLL.Helpers;
using TheBestCloth.BLL.ModelDatabase;

namespace TheBestCloth.API.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> RegisterUserAsync(string username, string password);
        Task<IEnumerable<User>> GetAllUsersAsync(PaginationParams paginationParams);
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<UserDTO> GetUserByUsernameAsync(string username);
        Task<UserDTO> LoginUserAsync(string username, string password);
    }
}

using System.Threading.Tasks;
using TheBestCloth.BLL.Helpers;
using TheBestCloth.BLL.ModelDatabase;

namespace TheBestCloth.BLL.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user);
        Task<IEnumerable<User>> GetAllUsersAsync(PaginationParams paginationParams);
        Task<User> GetUserById(int id);
        Task<User> GetUserByUsername(string username);
    }
}

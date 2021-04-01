using System.Threading.Tasks;
using TheBestCloth.BLL.Domain;
using TheBestCloth.BLL.Helpers;

namespace TheBestCloth.BLL.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user);
        Task<IEnumerable<User>> GetAllUsersAsync(PaginationParams paginationParams);
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
    }
}

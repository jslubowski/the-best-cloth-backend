using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TheBestCloth.BLL.Helpers;
using TheBestCloth.BLL.Interfaces;
using TheBestCloth.BLL.ModelDatabase;
using TheBestCloth.DAL.Data;
using TheBestCloth.DAL.Extensions;

namespace TheBestCloth.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(PostgresContext context)
        {
            _context = context;
        }
        private readonly PostgresContext _context;

        public async Task<User> AddUserAsync(User user)
        {
            var item = await _context.Users.AddAsync(user);
            return await _context.SaveChangesAndCheckSuccessAsync() ? item.Entity : null;
        }

        public Task<IEnumerable<User>> GetAllUsersAsync(PaginationParams paginationParams)
        {
            var usersQueryable = _context.Users.AsQueryable();
            return IEnumerable<User>.CreateAsync(
                usersQueryable,
                paginationParams.PageNumber,
                paginationParams.PageSize
                );
        }

        public Task<User> GetUserById(int id)
        {
            return _context.Users
                .FirstOrDefaultAsync(item => item.Id == id);
        }

        public Task<User> GetUserByUsername(string username)
        {
            return _context.Users
                .Where(item => item.Username == username)
                .SingleOrDefaultAsync();
        }
    }
}

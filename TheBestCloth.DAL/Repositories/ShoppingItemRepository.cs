using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TheBestCloth.DAL.Interfaces;
using TheBestCloth.DAL.Model;

namespace TheBestCloth.DAL.Repositories
{
    public class ShoppingItemRepository : IShoppingItemRepository
    {
        private readonly DbContext _context;
        public ShoppingItemRepository(DbContext context)
        {
            _context = context;
        }

        public Task<bool> AddShoppingItem(ShoppingItem shoppingItem)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> RemoveShoppingItem(ShoppingItem shoppingItem)
        {
            throw new System.NotImplementedException();
        }
    }
}

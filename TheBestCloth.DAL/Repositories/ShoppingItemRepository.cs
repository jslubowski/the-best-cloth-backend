using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TheBestCloth.BLL.Helpers;
using TheBestCloth.BLL.Interfaces;
using TheBestCloth.BLL.ModelDatabase;
using TheBestCloth.DAL.Data;

namespace TheBestCloth.DAL.Repositories
{
    public class ShoppingItemRepository : IShoppingItemRepository
    {
        private readonly PostgresContext _context;
        public ShoppingItemRepository(PostgresContext context)
        {
            _context = context;
        }

        public async Task<ShoppingItem> AddShoppingItemAsync(ShoppingItem shoppingItem)
        {
            var item = await _context.ShoppingItems.AddAsync(shoppingItem);
            await SaveChangesAsync();
            return item.Entity;
        }

        public Task<ShoppingItem> GetShoppingItemByIdAsync(int id)
        {
            return _context.ShoppingItems.FirstOrDefaultAsync(item => item.Id == id);
        }

        public Task<IEnumerable<ShoppingItem>> GetAllShoppingItemsListAsync(PaginationParams paginationParams)
        {
            var shoppingItemsQueryable = _context.ShoppingItems.AsQueryable();
            return IEnumerable<ShoppingItem>.CreateAsync(
                shoppingItemsQueryable,
                paginationParams.PageNumber,
                paginationParams.PageSize);
        }

        public async Task<bool> RemoveShoppingItemAsync(int id)
        {
            var shoppingItemToDelete = await _context.ShoppingItems.FirstOrDefaultAsync(item => item.Id == id);
            if (shoppingItemToDelete == null) return true;
            _context.ShoppingItems.Remove(shoppingItemToDelete);
            var executedCorrectly = await _context.SaveChangesAsync();
            return await SaveChangesAsync();
        }

        private async Task<bool> SaveChangesAsync()
        {
            var executedCorrectly = await _context.SaveChangesAsync();
            if (executedCorrectly > 0) return true;
            else return false;
        }

        public async Task<ShoppingItem> UpdateShoppingItemAsync(ShoppingItem shoppingItem)
        {
            var shoppingItemFound = await _context.ShoppingItems.FirstOrDefaultAsync(item => item.Id == shoppingItem.Id);
            if (shoppingItemFound == null) return Task.FromResult<ShoppingItem>(null).Result;
            _context.Entry(shoppingItemFound).State = EntityState.Detached;

            _context.ShoppingItems.Attach(shoppingItem);
            _context.Entry(shoppingItem).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return shoppingItem;
        }
    }
}

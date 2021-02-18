using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TheBestCloth.BLL.Exceptions;
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
            return _context.ShoppingItems
                .Include(item => item.Photos)
                .FirstOrDefaultAsync(item => item.Id == id);
        }

        public Task<IEnumerable<ShoppingItem>> GetAllShoppingItemsListAsync(PaginationParams paginationParams)
        {
            var shoppingItemsQueryable = _context.ShoppingItems
                .AsQueryable()
                .Include(item => item.Photos);
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
            var executedCorrectly = await SaveChangesAsync();
            return executedCorrectly;
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

        public async Task<Photo> AddPhotoForItemAsync(Photo photo, int shoppingItemId)
        {
            var shoppingItem = await GetShoppingItemByIdAsync(shoppingItemId);
            if (shoppingItem == null) return null;
            shoppingItem.Photos.Add(photo);
            if (await SaveChangesAsync()) return photo;
            else throw new DatabaseException($"Failed to add photo to item with ID: {shoppingItemId} in database");
        }

        public async Task<bool> RemovePhotoFromShoppingItemAsync(int photoId, int shoppingItemId)
        {
            var shoppingItem = await GetShoppingItemByIdAsync(shoppingItemId);
            if (shoppingItem == null) return false;
            var photoToRemove = shoppingItem.Photos.Where(photo => photo.Id == photoId).SingleOrDefault();
            if (photoToRemove == null) return false;
            shoppingItem.Photos.Remove(photoToRemove);
            return await SaveChangesAsync();
        }
    }
}

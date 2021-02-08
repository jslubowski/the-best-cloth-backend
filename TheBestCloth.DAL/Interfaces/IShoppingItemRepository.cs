using System.Threading.Tasks;
using TheBestCloth.API.Helpers;
using TheBestCloth.DAL.Model;

namespace TheBestCloth.DAL.Interfaces
{
    public interface IShoppingItemRepository
    {
        Task<bool> AddShoppingItemAsync(ShoppingItem shoppingItem);
        Task<bool> RemoveShoppingItemAsync(int id);
        Task<ShoppingItem> GetShoppingItemByIdAsync(int id);
        Task<PagedList<ShoppingItem>> GetShoppingItemsListAsync(PaginationParams paginationParams);
    }
}

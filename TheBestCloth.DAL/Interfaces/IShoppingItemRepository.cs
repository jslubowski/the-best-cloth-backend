using System.Threading.Tasks;
using TheBestCloth.DAL.Helpers;
using TheBestCloth.DAL.Model;

namespace TheBestCloth.DAL.Interfaces
{
    public interface IShoppingItemRepository
    {
        Task<ShoppingItem> AddShoppingItemAsync(ShoppingItem shoppingItem);
        Task<bool> RemoveShoppingItemAsync(int id);
        Task<ShoppingItem> GetShoppingItemByIdAsync(int id);
        Task<PagedList<ShoppingItem>> GetAllShoppingItemsListAsync(PaginationParams paginationParams);
    }
}

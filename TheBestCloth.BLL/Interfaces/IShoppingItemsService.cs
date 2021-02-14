using System.Threading.Tasks;
using TheBestCloth.DAL.Helpers;
using TheBestCloth.DAL.Model;

namespace TheBestCloth.BLL.Interfaces
{
    public interface IShoppingItemsService
    {
        Task<ShoppingItem> AddShoppingItemAsync(ShoppingItem shoppingItem);
        Task<bool> RemoveShoppingItemAsync(int id);
        Task<ShoppingItem> GetShoppingItemById(int id);
        Task<PagedList<ShoppingItem>> GetAllShoppingItemsAsync(PaginationParams paginationParams);
    }
}

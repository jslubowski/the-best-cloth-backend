using System.Threading.Tasks;
using TheBestCloth.BLL.Helpers;
using TheBestCloth.BLL.ModelDatabase;

namespace TheBestCloth.API.Interfaces
{
    public interface IShoppingItemsService
    {
        Task<ShoppingItem> AddShoppingItemAsync(ShoppingItem shoppingItem);
        Task<bool> RemoveShoppingItemAsync(int id);
        Task<ShoppingItem> GetShoppingItemById(int id);
        Task<IEnumerable<ShoppingItem>> GetAllShoppingItemsAsync(PaginationParams paginationParams);
        Task<ShoppingItem> UpdateShoppingItemAsync(ShoppingItem shoppingItem);
    }
}

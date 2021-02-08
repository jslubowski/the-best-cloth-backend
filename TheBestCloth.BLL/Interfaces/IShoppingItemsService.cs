using System.Threading.Tasks;
using TheBestCloth.BLL.Domain;
using TheBestCloth.DAL.Model;

namespace TheBestCloth.BLL.Interfaces
{
    public interface IShoppingItemsService
    {
        Task<bool> AddShoppingItemAsync(ShoppingItem shoppingItem);
        Task<bool> RemoveShoppingItemAsync(int id);
        Task<ShoppingItemDto> GetShoppingItemById(int id);
    }
}

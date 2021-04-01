using System.Threading.Tasks;
using TheBestCloth.BLL.Domain;
using TheBestCloth.BLL.Helpers;

namespace TheBestCloth.BLL.Interfaces
{
    public interface IShoppingItemRepository
    {
        Task<ShoppingItem> AddShoppingItemAsync(ShoppingItem shoppingItem);
        Task<bool> RemoveShoppingItemAsync(int id);
        Task<ShoppingItem> GetShoppingItemByIdAsync(int id);
        Task<IEnumerable<ShoppingItem>> GetAllShoppingItemsListAsync(PaginationParams paginationParams);
        Task<ShoppingItem> UpdateShoppingItemAsync(ShoppingItem shoppingItem);
        Task<Photo> AddPhotoForItemAsync(Photo photo, int shoppingItemId);
        Task<bool> RemovePhotoFromShoppingItemAsync(int photoId, int shoppingItemId);
    }
}

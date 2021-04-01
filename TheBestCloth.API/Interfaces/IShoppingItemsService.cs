using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TheBestCloth.BLL.Domain;
using TheBestCloth.BLL.Helpers;

namespace TheBestCloth.API.Interfaces
{
    public interface IShoppingItemsService
    {
        Task<ShoppingItem> AddShoppingItemAsync(ShoppingItem shoppingItem);
        Task<bool> RemoveShoppingItemAsync(int id);
        Task<ShoppingItem> GetShoppingItemById(int id);
        Task<IEnumerable<ShoppingItem>> GetAllShoppingItemsAsync(PaginationParams paginationParams);
        Task<ShoppingItem> UpdateShoppingItemAsync(ShoppingItem shoppingItem);
        Task<Photo> AddPhotoForItemAsync(IFormFile photo, int shoppingItemId);
        Task<bool> RemovePhotoFromShoppingItemAsync(int photoId, int shoppingItemId);
    }
}

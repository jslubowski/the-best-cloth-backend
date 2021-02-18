using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using TheBestCloth.API.Exceptions;
using TheBestCloth.API.Interfaces;
using TheBestCloth.BLL.Exceptions;
using TheBestCloth.BLL.Helpers;
using TheBestCloth.BLL.Interfaces;
using TheBestCloth.BLL.ModelDatabase;

namespace TheBestCloth.API.Service
{
    public class ShoppingItemsService : IShoppingItemsService
    {
        private readonly IShoppingItemRepository _repository;
        private readonly ICloudinaryService _cloudinaryService;
        public ShoppingItemsService(IShoppingItemRepository repository, ICloudinaryService cloudinaryService)
        {
            _repository = repository;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<Photo> AddPhotoForItemAsync(IFormFile photo, int shoppingItemId)
        {
            var uploadResult = await _cloudinaryService.AddPhotoAsync(photo);

            if (uploadResult.Error != null) return null;

            var photoEntity = new Photo
            {
                PhotoUrl = uploadResult.SecureUrl.AbsoluteUri,
                PublicId = uploadResult.PublicId
            };

            return await _repository.AddPhotoForItemAsync(photoEntity, shoppingItemId);
        }

        public async Task<ShoppingItem> AddShoppingItemAsync(ShoppingItem shoppingItem)
        {
            return await _repository.AddShoppingItemAsync(shoppingItem);
        }

        public Task<IEnumerable<ShoppingItem>> GetAllShoppingItemsAsync(PaginationParams paginationParams)
        {
            if (paginationParams.PageNumber < 0) return Task.FromResult<IEnumerable<ShoppingItem>>(null);
            return _repository.GetAllShoppingItemsListAsync(paginationParams);
        }

        public async Task<ShoppingItem> GetShoppingItemById(int id)
        {
            var shoppingItem = await _repository.GetShoppingItemByIdAsync(id);
            return shoppingItem;
        }

        public async Task<bool> RemoveShoppingItemAsync(int id)
        {
            var itemToRemove = await _repository.GetShoppingItemByIdAsync(id);
            foreach (var photo in itemToRemove.Photos)
            {
                var result = await _cloudinaryService.DeletePhotoAsync(photo.PublicId);
                if (result.Error != null) throw new CloudinaryConnectionException($"Can't remove photo with public ID: {photo.PublicId}");
            }
            return await _repository.RemoveShoppingItemAsync(id);
        }

        public async Task<ShoppingItem> UpdateShoppingItemAsync(ShoppingItem shoppingItem)
        {
            return await _repository.UpdateShoppingItemAsync(shoppingItem);
        }

        public async Task<bool> RemovePhotoFromShoppingItemAsync(int photoId, int shoppingItemId)
        {
            var shoppingItem = await _repository.GetShoppingItemByIdAsync(shoppingItemId);

            if (shoppingItem == null) throw new EntityNotFoundException($"Shopping item with ID {shoppingItemId} not found!");

            var photoToRemove = shoppingItem.Photos.Where(photo => photo.Id == photoId).SingleOrDefault();
            
            if (photoToRemove == null) return false;

            var result = await _cloudinaryService.DeletePhotoAsync(photoToRemove.PublicId);

            if (result.Error != null) throw new CloudinaryConnectionException($"Can't remove photo with public ID: {photoToRemove.PublicId}");

            return await _repository.RemovePhotoFromShoppingItemAsync(photoId, shoppingItemId);
        }
    }
}

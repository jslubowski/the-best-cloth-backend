using System.Threading.Tasks;
using TheBestCloth.API.Interfaces;
using TheBestCloth.BLL.Helpers;
using TheBestCloth.BLL.Interfaces;
using TheBestCloth.BLL.ModelDatabase;

namespace TheBestCloth.API.Service
{
    public class ShoppingItemsService : IShoppingItemsService
    {
        private readonly IShoppingItemRepository _repository;
        public ShoppingItemsService(IShoppingItemRepository repository)
        {
            _repository = repository;
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
            return await _repository.RemoveShoppingItemAsync(id);
        }

        public async Task<ShoppingItem> UpdateShoppingItemAsync(ShoppingItem shoppingItem)
        {
            return await _repository.UpdateShoppingItemAsync(shoppingItem);
        }
    }
}

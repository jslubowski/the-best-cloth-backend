using System.Threading.Tasks;
using TheBestCloth.BLL.Exceptions;
using TheBestCloth.BLL.Interfaces;
using TheBestCloth.DAL.Helpers;
using TheBestCloth.DAL.Interfaces;
using TheBestCloth.DAL.Model;

namespace TheBestCloth.BLL.Service
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

        public Task<PagedList<ShoppingItem>> GetAllShoppingItemsAsync(PaginationParams paginationParams)
        {
            return _repository.GetAllShoppingItemsListAsync(paginationParams);
        }

        public async Task<ShoppingItem> GetShoppingItemById(int id)
        {
            var shoppingItem = await _repository.GetShoppingItemByIdAsync(id);
            if (shoppingItem == null) throw new EntityNotFoundException($"Shopping item with id: {id} not found");
            return shoppingItem;
        }

        public async Task<bool> RemoveShoppingItemAsync(int id)
        {
            return await _repository.RemoveShoppingItemAsync(id);
        }
    }
}

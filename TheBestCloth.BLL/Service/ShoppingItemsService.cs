using AutoMapper;
using System.Threading.Tasks;
using TheBestCloth.BLL.Domain;
using TheBestCloth.BLL.Exceptions;
using TheBestCloth.BLL.Interfaces;
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
        public async Task<bool> AddShoppingItemAsync(ShoppingItem shoppingItem)
        {
            return await _repository.AddShoppingItemAsync(shoppingItem);
        }

        public async Task<ShoppingItemDto> GetShoppingItemById(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ShoppingItem, ShoppingItemDto>());
            var mapper = new Mapper(config);
            var shoppingItem = await _repository.GetShoppingItemByIdAsync(id);
            if (shoppingItem == null) throw new EntityNotFoundException($"Shopping item with id: {id} not found");
            var shoppingItemDto = mapper.Map<ShoppingItemDto>(shoppingItem);
            return shoppingItemDto;
        }

        public async Task<bool> RemoveShoppingItemAsync(int id)
        {
            return await _repository.RemoveShoppingItemAsync(id);
        }
    }
}

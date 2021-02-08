using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TheBestCloth.BLL.Domain;
using TheBestCloth.BLL.Interfaces;
using TheBestCloth.DAL.Model;

namespace TheBestCloth.API.Controllers
{
    public class ShoppingItemsController : BaseApiController
    {
        private readonly IShoppingItemsService _shoppingItemsService;
        public ShoppingItemsController(IShoppingItemsService shoppingItemsService)
        {
            _shoppingItemsService = shoppingItemsService;
        }
        [HttpPost("add")]
        public async Task<ActionResult> AddShoppingItemAsync([FromBody] ShoppingItem shoppingItem)
        {
            var successful = await _shoppingItemsService.AddShoppingItemAsync(shoppingItem);
            if (successful) return Ok();
            return BadRequest();

        }

        [HttpGet("{id}", Name = "GetShoppingItem")]
        public async Task<ActionResult<ShoppingItemDto>> GetShoppingItemByIdAsync(int id)
        {
            return await _shoppingItemsService.GetShoppingItemById(id);

        }

    }
}

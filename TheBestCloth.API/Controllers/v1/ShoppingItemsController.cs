using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TheBestCloth.API.Extensions;
using TheBestCloth.API.Interfaces;
using TheBestCloth.BLL.Exceptions;
using TheBestCloth.BLL.Helpers;
using TheBestCloth.BLL.ModelDatabase;

namespace TheBestCloth.API.Controllers
{
    public class ShoppingItemsController : BaseApiController
    {
        private readonly IShoppingItemsService _shoppingItemsService;
        public ShoppingItemsController(IShoppingItemsService shoppingItemsService)
        {
            _shoppingItemsService = shoppingItemsService;
        }

        [HttpPost("add", Name = "add-shopping-item")]
        public async Task<ActionResult<ShoppingItem>> AddShoppingItemAsync([FromBody] ShoppingItem shoppingItem)
        {
            var createdItem = await _shoppingItemsService.AddShoppingItemAsync(shoppingItem);
            if (createdItem != null) return CreatedAtRoute("get-shopping-item", new { id = createdItem.Id }, createdItem);
            return BadRequest("Failed to add object!");

        }

        [HttpGet("{id}", Name = "get-shopping-item")]
        public async Task<ActionResult<ShoppingItem>> GetShoppingItemByIdAsync(int id)
        {
            var item = await _shoppingItemsService.GetShoppingItemById(id);
            if (item != null) return Ok(item);
            return BadRequest(new { message = $"Failed to fetch item with id: {id}!" });

        }

        [HttpGet("all", Name = "get-all-shopping-items")]
        public async Task<ActionResult<IEnumerable<ShoppingItem>>> GetAllShopingItemsAsync([FromQuery] PaginationParams paginationParams)
        {
            var shoppingItems = await _shoppingItemsService.GetAllShoppingItemsAsync(paginationParams);
            if (shoppingItems == null) return BadRequest();

            Response.AddPaginationHeader(shoppingItems.CurrentPage, paginationParams.PageSize, shoppingItems.TotalCount, shoppingItems.TotalPages);

            return shoppingItems;
        }

        [HttpPut(Name = "update-shopping-item")]
        public async Task<ActionResult<ShoppingItem>> UpdateShoppingItemAsync([FromBody] ShoppingItem shoppingItem)
        {
            var shoppingItemUpdated = await _shoppingItemsService.UpdateShoppingItemAsync(shoppingItem);
            if (shoppingItemUpdated == null) return BadRequest(new { message = $"Cannot find shopping item with given id: {shoppingItem.Id}" });
            return Ok(shoppingItemUpdated);
        }

        [HttpDelete("{shoppingItemId}", Name = "remove-shopping-item")]
        public async Task<ActionResult> RemoveShoppingItemAsync(int shoppingItemId)
        {
            var isRemovalSuccessful = await _shoppingItemsService.RemoveShoppingItemAsync(shoppingItemId);
            if (isRemovalSuccessful) return Ok();
            return BadRequest($"Cannot remove shopping item with ID: {shoppingItemId}");
        }

        [HttpPost("{id}/photos", Name = "add-photo")]
        public async Task<ActionResult<Photo>> AddPhotoForShoppingItemAsync([FromForm] IFormFile photo, int id)
        {
            var photoAdded = await _shoppingItemsService.AddPhotoForItemAsync(photo, id);
            if (photoAdded == null) return BadRequest($"Can't find photo with ID: {id}");
            else return Ok(photoAdded);
        }

        [HttpDelete("{shoppingItemId}/photos/{photoId}")]
        public async Task<ActionResult> RemovePhotoForShoppingItem(int shoppingItemId, int photoId)
        {
            var isRemovalSuccessful = false;
            try
            {
                isRemovalSuccessful = await _shoppingItemsService.RemovePhotoFromShoppingItemAsync(photoId, shoppingItemId);
            }
            catch (EntityNotFoundException ex)
            {
                return BadRequest("Cannot find entity." + ex.ToString());
            }

            if (isRemovalSuccessful) return Ok();
            return BadRequest($"Cannot remove photo with ID: {photoId} from photo with ID: {shoppingItemId}");
        }

    }
}

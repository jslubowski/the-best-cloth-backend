using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBestCloth.API.Extensions;
using TheBestCloth.API.Models;
using TheBestCloth.BLL.Interfaces;
using TheBestCloth.DAL.Helpers;
using TheBestCloth.DAL.Model;

namespace TheBestCloth.API.Controllers
{
    public class ShoppingItemsController : BaseApiController
    {
        private readonly IShoppingItemsService _shoppingItemsService;
        public ShoppingItemsController(IShoppingItemsService shoppingItemsService, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider, IMapper mapper)
            : base(actionDescriptorCollectionProvider, mapper)
        {
            _shoppingItemsService = shoppingItemsService;
        }
        [HttpPost("add", Name = "add-shopping-item")]
        public async Task<ActionResult<ShoppingItem>> AddShoppingItemAsync([FromBody] ShoppingItem shoppingItem)
        {
            var successful = await _shoppingItemsService.AddShoppingItemAsync(shoppingItem);
            if (successful != null) return Ok(successful);
            return BadRequest();

        }

        [HttpGet("{id}", Name = "get-shopping-item")]
        public async Task<ActionResult<ShoppingItem>> GetShoppingItemByIdAsync(int id)
        {
            var item = await _shoppingItemsService.GetShoppingItemById(id);
            return Ok(HATEOASShoppingItem(item));

        }

        [HttpGet("all", Name = "get-all-shopping-items")]
        public async Task<ActionResult<IEnumerable<ShoppingItemModel>>> GetAllShopingItemsAsync([FromQuery] PaginationParams paginationParams)
        {
            var shoppingItems =  await _shoppingItemsService.GetAllShoppingItemsAsync(paginationParams);
 
            Response.AddPaginationHeader(shoppingItems.CurrentPage, paginationParams.PageSize, shoppingItems.TotalCount, shoppingItems.TotalPages);

            //TODO Add HATEOAS for list (next, prev)

            return shoppingItems
                .Select(item => HATEOASShoppingItem(item))
                .ToList();
        }

    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using TheBestCloth.API.Models;
using TheBestCloth.DAL.Model;

namespace TheBestCloth.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private readonly IReadOnlyList<ActionDescriptor> _routes;
        private readonly IMapper _mapper;

        public BaseApiController(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider, IMapper mapper)
        {
            _routes = actionDescriptorCollectionProvider.ActionDescriptors.Items;
            _mapper = mapper;
        }

        internal Link UrlLink(string relation, string routeName, object values)
        {
            var route = _routes.FirstOrDefault(f => f.AttributeRouteInfo.Name.Equals(routeName));
            var method = route.ActionConstraints
                .OfType<HttpMethodActionConstraint>()
                .First()
                .HttpMethods
                .First();
            var url = Url.Link(routeName, values).ToLower();
            return new Link(url, relation, method);
        }

        internal ShoppingItemModel HATEOASShoppingItem(ShoppingItem shoppingItem)
        {
            ShoppingItemModel shoppingItemModel = _mapper.Map<ShoppingItemModel>(shoppingItem);

            shoppingItemModel.Links.Add(
                UrlLink(
                    "all",
                    "get-all-shopping-items",
                    null
                ));

            shoppingItemModel.Links.Add(
                UrlLink(
                    "self",
                    "get-shopping-item",
                    new { id = shoppingItem.Id }
                ));

            return shoppingItemModel;
        }
    }
}

using AutoMapper;
using TheBestCloth.API.Models;
using TheBestCloth.DAL.Model;

namespace TheBestCloth.API.Helpers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<ShoppingItem, ShoppingItemModel>();
        }
    }
}

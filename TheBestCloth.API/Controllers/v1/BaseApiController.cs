using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace TheBestCloth.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private readonly IMapper _mapper;

        public BaseApiController(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider, IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}

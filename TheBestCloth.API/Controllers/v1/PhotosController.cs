using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TheBestCloth.API.Interfaces;
using TheBestCloth.BLL.Domain;

namespace TheBestCloth.API.Controllers.v1
{
    public class PhotosController : BaseApiController
    {
        public PhotosController(ICloudinaryService cloudinaryService)
        {
            _cloudinaryService = cloudinaryService;
        }
        private readonly ICloudinaryService _cloudinaryService;

        [HttpPost]
        public async Task<ActionResult<PhotoDto>> UploadPhotoToCloudinaryAsync([FromForm] IFormFile photo)
        {
            var photoItem = await _cloudinaryService.AddPhotoAsync(photo);

            if (photoItem == null) return StatusCode(500);

            else return Ok(photoItem);
        }
    }
}

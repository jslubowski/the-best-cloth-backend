using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TheBestCloth.API.Interfaces;
using TheBestCloth.BLL.DTOs;
using TheBestCloth.BLL.Helpers;

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
        [Authorize(Policy = Roles.Moderator)]
        public async Task<ActionResult<PhotoDto>> UploadPhotoToCloudinaryAsync([FromForm] IFormFile photo)
        {
            var photoItem = await _cloudinaryService.AddPhotoAsync(photo);

            if (photoItem == null) return StatusCode(500);

            else return Ok(photoItem);
        }
    }
}

using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TheBestCloth.BLL.DTOs;

namespace TheBestCloth.API.Interfaces
{
    public interface ICloudinaryService
    {
        Task<PhotoDto> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}

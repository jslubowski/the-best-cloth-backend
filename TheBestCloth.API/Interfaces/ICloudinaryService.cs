﻿using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TheBestCloth.BLL.Domain;

namespace TheBestCloth.API.Interfaces
{
    public interface ICloudinaryService
    {
        Task<PhotoDTO> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}

using Microsoft.AspNetCore.Http;
using Supermarket.Application.ModelResponses;

namespace Supermarket.Application.Abstractions.IImageservices
{
        public interface IImageServices
        {
            Task<ResponseImage> SaveImageAsync(string folderPath, IFormFile? file);
        }
}

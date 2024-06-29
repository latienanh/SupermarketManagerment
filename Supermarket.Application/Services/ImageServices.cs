using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Supermarket.Application.IServices;
using Supermarket.Application.ModelResponses;

namespace Supermarket.Application.Services
{
    public class ImageServices : IImageServices
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ImageServices(IWebHostEnvironment _webHostEnvironment)
        {
            this._webHostEnvironment = _webHostEnvironment;
        }
        public async Task<ResponseImage?> SaveImageAsync(string folderPath, IFormFile? file)
        {
            if (file!=null)
            {
                if (file.Length > 2 * 1024 * 1024) // Giới hạn kích thước file là 2MB
                {
                    return new ResponseImage()
                    {
                        isSuccess = false,
                        Message = "File quá 2MB"
                    };
                }

                // Kiểm tra định dạng file
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var fileExtension = Path.GetExtension(file.FileName).ToLower();
                if (!allowedExtensions.Contains(fileExtension))
                {
                    return new ResponseImage()
                    {
                        isSuccess = false,
                        Message = "Chỉ hỗ trợ file .jpg .jpeg . png .gif"
                    };
                }

                folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
                var serverFolder = Path.Combine(_webHostEnvironment.WebRootPath,folderPath);
                using (var stream = System.IO.File.Create(serverFolder))
                {
                    await file.CopyToAsync(stream);
                }

                return new ResponseImage()
                {
                    isSuccess = true,
                    Message = "Thành công",
                    Data = "/" +folderPath
                };
              
            }

            return null;
        }
    }
}

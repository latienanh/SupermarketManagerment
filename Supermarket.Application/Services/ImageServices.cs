using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Supermarket.Application.IServices;

namespace Supermarket.Application.Services
{
    public class ImageServices : IImageServices
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ImageServices(IWebHostEnvironment _webHostEnvironment)
        {
            this._webHostEnvironment = _webHostEnvironment;
        }
        public async Task<string> SaveImageAsync(string folderPath, IFormFile? file)
        {
            if (file!=null)
            {
                folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
                var serverFolder = Path.Combine(_webHostEnvironment.WebRootPath,folderPath);
                using (var stream = System.IO.File.Create(serverFolder))
                {
                    await file.CopyToAsync(stream);
                }

                return "/"+folderPath;
            }

            return null;
        }
    }
}

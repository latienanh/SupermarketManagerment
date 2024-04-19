using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Supermarket.Application.IServices
{
    public interface IImageServices
    {
        Task<string> SaveImageAsync(string folderPath,IFormFile? file);
    }
}

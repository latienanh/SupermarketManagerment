using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Application.IServices;
using Supermarket.Application.ModelResponses;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace Supermarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;
        private readonly IImageServices _imageServices;

        public ProductController(IProductServices productServices, IImageServices imageServices)
        {
            _productServices = productServices;
            _imageServices = imageServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productServices.GetAllAsync();
            if (result != null)
            {
                if (result.Any())
                    return Ok(new ResponseWithListSuccess<ProductResponseDto>
                    {
                        Message = "Tìm thấy thành công",
                        ListData = result
                    });
                return Ok(new ResponseWithListSuccess<ProductResponseDto>
                {
                    Message = "Không tìm thấy thông tin",
                    ListData = result
                });
            }

            return BadRequest(new ResponseFailure()
            {
                Message = "Lỗi",
            });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _productServices.GetByIdAsync(id);
            if (result != null)
                return Ok(new ResponseWithDataSuccess<ProductResponseDto>
                {
                    Message = "Tìm thấy thông tin",
                    Data = result
                });
            return BadRequest(new ResponseWithDataFailure<ProductResponseDto>
            {
                Message = "Không tìm thấy thông tin",
                Data = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create( [FromForm] string dataProductJson, IFormFile? imageProduct, IFormFileCollection? variantImages)
        {
            var model = JsonConvert.DeserializeObject<ProductRequestDto>(dataProductJson);
            var folderProduct = "images/products/";
            if (imageProduct != null)
            {
                var productImagePath = await _imageServices.SaveImageAsync(folderProduct,imageProduct);
                if (productImagePath == null)
                {
                    model.ProductImage = "/images/default-image.jpg";
                }
                model.ProductImage = productImagePath;
            }
            if (model.Variants != null)
            {
                for (int i = 0; i < model.Variants.Count(); i++)
                {
                    var variantImagePath = await _imageServices.SaveImageAsync(folderProduct, variantImages[i]);
                    if(variantImagePath == null)
                        model.Variants.ElementAt(i).ProductImage = "/images/default-image.jpg";
                    model.Variants.ElementAt(i).ProductImage=variantImagePath;
                }
            }

            var userId = new Guid(HttpContext.User.FindFirstValue("userId"));
            var result = await _productServices.CreateAsync(model, userId);
            if (result)
                return Ok(new ResponseSuccess()
                {
                    Message = "Tạo thành công!!!"
                });
            return BadRequest(new ResponseFailure()
            {
                Message = "Tạo không thành công!!!"
            });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userId = new Guid(HttpContext.User.FindFirstValue("userId"));
            var result = await _productServices.DeleteAsync(id, userId);
            if (result)
                return Ok(new ResponseSuccess()
                {
                    Message = "Xoá thành công",
                });
            return BadRequest(new ResponseFailure()
            {
                Message = "Xoá thất bại"
            });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, ProductRequestDto model)
        {
            var userId = new Guid(HttpContext.User.FindFirstValue("userId"));
            var result = await _productServices.UpdateAsync(model, id, userId);
            if (result)
                return Ok(new ResponseSuccess()
                {
                    Message = "Sửa thành công!!!"
                });
            return BadRequest(new ResponseFailure()
            {
                Message = "Sửa thất bại!!!"
            });
        }
    }
}

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
            if (result.IsNullOrEmpty())
                return BadRequest(new ResponseWithList<ProductResponseDto>
                {
                    Message = "Không có thông tin gì",
                    ListData = result
                }
                );
            return Ok(new ResponseWithList<ProductResponseDto>
            {
                Message = "Lấy thông tin thành công",
                ListData = result
            });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _productServices.GetByIdAsync(id);
            if (result == null)
                return BadRequest(new ResponseWithData<ProductResponseDto>
                {
                    Message = "Không có thông tin gì",
                    Data = result
                }
                );
            return Ok(new ResponseWithData<ProductResponseDto>
            {
                Message = "Lấy thông tin thành công",
                Data = result
            });
        }

        [HttpPost]
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
                return Ok(new ResponseBase());
            return BadRequest(new ResponseBase
            {
                Message = "Tạo không thành công"
            });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userId = new Guid(HttpContext.User.FindFirstValue("userId"));
            var result = await _productServices.DeleteAsync(id, userId);
            if (result)
                return Ok(new ResponseBase());
            return BadRequest(new ResponseBase
            {
                Message = "Xoá không thành công"
            });
        }
        [HttpPut]
        public async Task<IActionResult> Update(Guid id, ProductRequestDto model)
        {
            var userId = new Guid(HttpContext.User.FindFirstValue("userId"));
            var result = await _productServices.UpdateAsync(model, id, userId);
            if (result)
                return Ok(new ResponseBase());
            return BadRequest(new ResponseBase
            {
                Message = "Sửa không thành công"
            });
        }
    }
}

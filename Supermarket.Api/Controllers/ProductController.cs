using Microsoft.AspNetCore.Mvc;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.IServices;
using Supermarket.Application.ModelResponses;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

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
        [HttpGet("GetPaging")]
        public async Task<IActionResult> GetPaging(int index, int size)
        {
            var result = await _productServices.getPagingAsync(index, size);
            if (result != null)
            {
                if (result.Any())
                    return Ok(new ResponseWithListSuccess<ProductsPagingResponseDto>
                    {
                        Message = "Tìm thấy thành công",
                        ListData = result
                    });
                return Ok(new ResponseWithListSuccess<ProductsPagingResponseDto>
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
        [HttpGet("TotalPaging")]
        public async Task<IActionResult> GetTotalPaging(int size)
        {
            var result = await _productServices.getTotalPagingTask(size);
            if (result != null)
            {
                if (result > 0)
                    return Ok(new ResponseWithDataSuccess<int>()
                    {
                        Message = "Thành công",
                        Data = result
                    });
                return Ok(new ResponseWithDataFailure<int>()
                {
                    Message = "Thất bại",
                    Data = result
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
        public async Task<IActionResult> Create([FromForm] ProductRequestDto model)
        {
            //var model = JsonConvert.DeserializeObject<ProductRequestDto>(dataProductJson);
            var folderProduct = "images/products/";


            var productImagePath = await _imageServices.SaveImageAsync(folderProduct, model.Image);
            if (productImagePath == null)
            {
                model.PathImage = "/images/default-image.jpg";
            }
            else if (!productImagePath.isSuccess)
            {
                return BadRequest(new ResponseFailure()
                {
                    Message = productImagePath.Message,
                });
            }
            else
            {
                model.PathImage = productImagePath.Data;
            }


            if (model.Variants != null)
            {
                foreach (var variant in model.Variants)
                {
                    var variantImagePath = await _imageServices.SaveImageAsync(folderProduct, variant.Image);
                    if (variantImagePath == null)
                    {
                        variant.PathImage = "/images/default-image.jpg";
                    }
                    else if (!variantImagePath.isSuccess)
                    {
                        return BadRequest(new ResponseFailure()
                        {
                            Message = variantImagePath.Message,
                        });
                    }
                    else
                    {
                        variant.PathImage = variantImagePath.Data;
                    }
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
        public async Task<IActionResult> Update(Guid id, [FromForm] ProductRequestDto model)
        {
            var folderProduct = "images/products/";
            var productImagePath = await _imageServices.SaveImageAsync(folderProduct, model.Image);
            if (productImagePath == null)
            {
                model.PathImage = null;
            }
            else if (!productImagePath.isSuccess)
            {
                return BadRequest(new ResponseFailure()
                {   
                    Message = productImagePath.Message,
                });
            }
            else
            {
                model.PathImage = productImagePath.Data;
            }
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

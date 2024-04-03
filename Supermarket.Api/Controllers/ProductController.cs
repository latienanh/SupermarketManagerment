using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Application.IServices;
using Supermarket.Application.ModelResponses;

namespace Supermarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
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
        public async Task<IActionResult> GetById(int id)
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
        public async Task<IActionResult> Create([FromBody] ProductRequestDto model)
        {
            var result = await _productServices.CreateAsync(model);
            if (result)
                return Ok(new ResponseBase());
            return BadRequest(new ResponseBase
            {
                Message = "Tạo không thành công"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productServices.DeleteAsync(id);
            if (result)
                return Ok(new ResponseBase());
            return BadRequest(new ResponseBase
            {
                Message = "Xoá không thành công"
            });
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, ProductRequestDto model)
        {
            var result = await _productServices.UpdateAsync(model, id);
            if (result)
                return Ok(new ResponseBase());
            return BadRequest(new ResponseBase
            {
                Message = "Sửa không thành công"
            });
        }
    }
}

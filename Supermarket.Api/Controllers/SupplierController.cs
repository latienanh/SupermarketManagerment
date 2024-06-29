using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.IServices;
using Supermarket.Application.ModelResponses;
using System.Security.Claims;

namespace Supermarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierServices _supplierServices;

        public SupplierController(ISupplierServices supplierServices)
        {
            _supplierServices = supplierServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _supplierServices.GetAllAsync();
            if (result != null)
            {
                if (result.Any())
                    return Ok(new ResponseWithListSuccess<SupplierResponseDto>
                    {
                        Message = "Tìm thấy thành công",
                        ListData = result
                    });
                return Ok(new ResponseWithListSuccess<SupplierResponseDto>
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
            var result = await _supplierServices.getPagingAsync(index, size);
            if (result != null)
            {
                if (result.Any())
                    return Ok(new ResponseWithListSuccess<SupplierResponseDto>
                    {
                        Message = "Tìm thấy thành công",
                        ListData = result
                    });
                return Ok(new ResponseWithListSuccess<SupplierResponseDto>
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
            var result = await _supplierServices.getTotalPagingTask(size);
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
            var result = await _supplierServices.GetByIdAsync(id);
            if (result != null)
                return Ok(new ResponseWithDataSuccess<SupplierResponseDto>
                {
                    Message = "Tìm thấy thông tin",
                    Data = result
                });
            return BadRequest(new ResponseWithDataFailure<SupplierResponseDto>
            {
                Message = "Không tìm thấy thông tin",
                Data = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SupplierRequestDto model)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
            var result = await _supplierServices.CreateAsync(model, userId);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(SupplierRequestDto model, Guid id)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
            var result = await _supplierServices.UpdateAsync(model, id, userId);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
            var result = await _supplierServices.DeleteAsync(id, userId);
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
    }
}

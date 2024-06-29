using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.IRepositories;
using Supermarket.Application.IServices;
using Supermarket.Application.ModelResponses;

namespace Supermarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public readonly ICustomerServices _customerServices;
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices=customerServices;
 
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customerServices.GetAllAsync();
            if (result != null)
            {
                if (result.Any())
                    return Ok(new ResponseWithListSuccess<CustomerResponseDto>
                    {
                        Message = "Tìm thấy thành công",
                        ListData = result
                    });
                return Ok(new ResponseWithListSuccess<CustomerResponseDto>
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
            var result = await _customerServices.getPagingAsync(index, size);
            if (result != null)
            {
                if (result.Any())
                    return Ok(new ResponseWithListSuccess<CustomerResponseDto>
                    {
                        Message = "Tìm thấy thành công",
                        ListData = result
                    });
                return Ok(new ResponseWithListSuccess<CustomerResponseDto>
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
            var result = await _customerServices.getTotalPagingTask(size);
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
            var result = await _customerServices.GetByIdAsync(id);
            if (result != null)
                return Ok(new ResponseWithDataSuccess<CustomerResponseDto>
                {
                    Message = "Tìm thấy thông tin",
                    Data = result
                });
            return BadRequest(new ResponseWithDataFailure<CustomerResponseDto>
            {
                Message = "Không tìm thấy thông tin",
                Data = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerRequestDto entity)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
            var result = await _customerServices.CreateAsync(entity, userId);
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
        public async Task<IActionResult> Update(CustomerRequestDto entity, Guid id)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
            var result = await _customerServices.UpdateAsync(entity, id, userId);
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
            var result = await _customerServices.DeleteAsync(id, userId);
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

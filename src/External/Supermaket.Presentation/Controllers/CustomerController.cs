using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.ModelResponses;
using Supermarket.Application.Services.Customer.Commands.CreateCustomer;
using Supermarket.Application.Services.Customer.Commands.DeleteCustomer;
using Supermarket.Application.Services.Customer.Commands.UpdateCustomer;
using Supermarket.Application.Services.Customer.Queries.SQLServerQueries.GetAllCustomers;
using Supermarket.Application.Services.Customer.Queries.SQLServerQueries.GetCustomerById;
using Supermarket.Application.Services.Customer.Queries.SQLServerQueries.GetPagingCustomers;
using Supermarket.Application.Services.Customer.Queries.SQLServerQueries.GetTotalPagingCustomers;

namespace Supermarket.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ApiController
    {
        [HttpGet("sql")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllCustomersQuery();

            var result = await Sender.Send(query);
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

        [HttpGet("sql/GetPaging")]
        public async Task<IActionResult> GetPaging(int index, int size)
        {
            var query = new GetPagingCustomersQuery(index,size);

            var result = await Sender.Send(query);
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
        [HttpGet("sql/TotalPaging")]
        public async Task<IActionResult> GetTotalPaging(int size)
        {
            var query = new GetTotalPagingCustomersQuery(size);

            var result = await Sender.Send(query);
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
        [HttpGet("sql/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetCustomerByIdQuery(id);

            var result = await Sender.Send(query);
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
        public async Task<IActionResult> Create([FromBody] CreateCustomerRequest entity)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
            var command = new CreateCustomerCommand(entity, userId);
            var result = await Sender.Send(command);
            if (result!=null)
                return Ok(new ResponseSuccess()
                {
                    Message = "Tạo thành công!!!"
                });
            return BadRequest(new ResponseFailure()
            {
                Message = "Tạo không thành công!!!"
            });
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCustomerRequest entity)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
            var command = new UpdateCustomerCommand(entity, userId);
            var result = await Sender.Send(command);
            if (result != null)
                return Ok(new ResponseSuccess()
                {
                    Message = "Sửa thành công!!!"
                });
            return BadRequest(new ResponseFailure()
            {
                Message = "Sửa thất bại!!!"
            });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteCustomerRequest deleteCustomerRequest)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
            var command = new DeleteCustomerCommand(deleteCustomerRequest, userId);
            var result = await Sender.Send(command);
            if (result != null)
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

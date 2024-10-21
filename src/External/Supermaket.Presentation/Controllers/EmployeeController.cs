using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Application.Abstractions.IImageservices;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.ModelResponses;
using Supermarket.Application.Services.Employee.Commands.CreateEmployee;
using Supermarket.Application.Services.Employee.Commands.DeleteEmployee;
using Supermarket.Application.Services.Employee.Commands.UpdateEmployee;
using Supermarket.Application.Services.Employee.Queries.SQLServerQueries.GetAllEmployees;
using Supermarket.Application.Services.Employee.Queries.SQLServerQueries.GetEmployeeById;
using Supermarket.Application.Services.Employee.Queries.SQLServerQueries.GetPagingEmployees;
using Supermarket.Application.Services.Employee.Queries.SQLServerQueries.GetTotalPagingEmployees;

namespace Supermarket.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ApiController
    {
        private readonly IImageServices _imageServices;

        public EmployeeController(IImageServices _imageServices)
        {
            this._imageServices = _imageServices;
        }

        [HttpGet("sql")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllEmployeesQuery();

            var result = await Sender.Send(query);
            if (result != null)
            {
                if (result.Any())
                    return Ok(new ResponseWithListSuccess<EmployeeResponseDto>
                    {
                        Message = "Tìm thấy thành công",
                        ListData = result
                    });
                return Ok(new ResponseWithListSuccess<EmployeeResponseDto>
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
            var query = new GetPagingEmployeesQuery(index,size);

            var result = await Sender.Send(query);
            if (result != null)
            {
                if (result.Any())
                    return Ok(new ResponseWithListSuccess<EmployeeResponseDto>
                    {
                        Message = "Tìm thấy thành công",
                        ListData = result
                    });
                return Ok(new ResponseWithListSuccess<EmployeeResponseDto>
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
            var query = new GetTotalPagingEmployeesQuery(size);

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
            var query = new GetEmployeeByIdQuery(id);

            var result = await Sender.Send(query);
            if (result != null)
                return Ok(new ResponseWithDataSuccess<EmployeeResponseDto>
                {
                    Message = "Tìm thấy thông tin",
                    Data = result
                });
            return BadRequest(new ResponseWithDataFailure<EmployeeResponseDto>
            {
                Message = "Không tìm thấy thông tin",
                Data = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateEmployeeRequest model)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
            var folderEmployees = "images/employees/";

            var employeesImagePath = await _imageServices.SaveImageAsync(folderEmployees, model.Image);
            if (employeesImagePath == null)
            {
                model.PathImage = "/images/default-image.jpg";
            }
            else if (!employeesImagePath.isSuccess)
            {
                return BadRequest(new ResponseFailure()
                {
                    Message = employeesImagePath.Message,
                });
            }
            else
            {
                model.PathImage = employeesImagePath.Data;
            }
            var command = new CreateEmployeeCommand(model, userId);
            var result = await Sender.Send(command);
            if (result != null)
                return Ok(new ResponseSuccess()
                {
                    Message = "Tạo thành công!!!"
                });
            return BadRequest(new ResponseFailure()
            {
                Message = "Tạo không thành công!!!"
            });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteEmployeeRequest deleteEmployeeRequest)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
            var command = new DeleteEmployeeCommand(deleteEmployeeRequest, userId);
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
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateEmployeeRequest model)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
            var folderEmployees = "images/employees/";


            var employeesImagePath = await _imageServices.SaveImageAsync(folderEmployees, model.Image);
            if (employeesImagePath == null)
            {
                model.PathImage = null;
            }
            else if (!employeesImagePath.isSuccess)
            {
                return BadRequest(new ResponseFailure()
                {
                    Message = employeesImagePath.Message
                });
            }
            else
            {
                model.PathImage = employeesImagePath.Data;
            }

            var command = new UpdateEmployeeCommand(model, userId);
            var result = await Sender.Send(command);
            if (result!=null)
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

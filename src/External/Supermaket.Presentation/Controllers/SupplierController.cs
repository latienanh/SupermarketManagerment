using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.ModelResponses;
using Supermarket.Application.Services.Supplier.Commands.CreateSupplier;
using Supermarket.Application.Services.Supplier.Commands.DeleteSupplier;
using Supermarket.Application.Services.Supplier.Commands.UpdateSupplier;
using Supermarket.Application.Services.Supplier.Queries.SQLServerQueries.GetAllSuppliers;
using Supermarket.Application.Services.Supplier.Queries.SQLServerQueries.GetPagingSuppliers;
using Supermarket.Application.Services.Supplier.Queries.SQLServerQueries.GetSupplierById;
using Supermarket.Application.Services.Supplier.Queries.SQLServerQueries.GetTotalPagingSuppliers;

namespace Supermarket.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SupplierController : ApiController
    {

        [HttpGet("sql")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllSuppliersQuery();

            var result = await Sender.Send(query);
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
        [HttpGet("sql/GetPaging")]
        public async Task<IActionResult> GetPaging(int index, int size)
        {
            var query = new GetPagingSuppliersQuery(index,size);

            var result = await Sender.Send(query);
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
        [HttpGet("sql/TotalPaging")]
        public async Task<IActionResult> GetTotalPaging(int size)
        {
            var query = new GetTotalPagingSuppliersQuery(size);

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
            var query = new GetSupplierByIdQuery(id);

            var result = await Sender.Send(query);
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
        public async Task<IActionResult> Create([FromBody] CreateSupplierRequest model,CancellationToken cancellationToken)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
            var command = new CreateSupplierCommand(model, userId);
            var result = Sender.Send(command, cancellationToken);
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
        public async Task<IActionResult> Update(UpdateSupplierRequest model, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
            var command = new UpdateSupplierCommand(model, userId);
            var result = Sender.Send(command, cancellationToken);
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

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteSupplierRequest deleteSupplierRequest,CancellationToken cancellationToken)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
            var command = new DeleteSupplierCommand(deleteSupplierRequest, userId);
            var result = Sender.Send(command, cancellationToken);
            if (result!=null)
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

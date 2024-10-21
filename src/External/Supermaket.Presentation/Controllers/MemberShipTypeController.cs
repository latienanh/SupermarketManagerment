using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.ModelResponses;
using Supermarket.Application.Services.Employee.Commands.CreateEmployee;
using Supermarket.Application.Services.MemberShipType.Commands.CreateMemberShipType;
using Supermarket.Application.Services.MemberShipType.Commands.DeleteMemberShipType;
using Supermarket.Application.Services.MemberShipType.Commands.UpdateMemberShipType;
using Supermarket.Application.Services.MemberShipType.Queries.SQLServerQueries.GetAllMemberShipTypes;
using Supermarket.Application.Services.MemberShipType.Queries.SQLServerQueries.GetMemberShipTypeById;
using Supermarket.Application.Services.MemberShipType.Queries.SQLServerQueries.GetPagingMemberShipTypes;
using Supermarket.Application.Services.MemberShipType.Queries.SQLServerQueries.GetTotalPagingMemberShipType;
using Supermarket.Application.Services.Product.Queries.SQLServerQueries.GetPagingProducts;
using Supermarket.Application.Services.Product.Queries.SQLServerQueries.GetTotalPagingProducts;
using Supermarket.Domain.Primitives;

namespace Supermarket.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MemberShipTypeController : ApiController
    {

        [HttpGet("sql")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllMemberShipTypesQuery();

            var result = await Sender.Send(query);
            if (result != null)
            {
                if (result.Any())
                    return Ok(new ResponseWithListSuccess<MemberShipTypeResposeDto>
                    {
                        Message = "Tìm thấy thành công",
                        ListData = result
                    });
                return Ok(new ResponseWithListSuccess<MemberShipTypeResposeDto>
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

        [HttpGet("sql/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetMemberShipTypeByIdQuery(id);

            var result = await Sender.Send(query);
            if (result != null)
                return Ok(new ResponseWithDataSuccess<MemberShipTypeResposeDto>
                {
                    Message = "Tìm thấy thông tin",
                    Data = result
                });
            return BadRequest(new ResponseWithDataFailure<MemberShipTypeResposeDto>
            {
                Message = "Không tìm thấy thông tin",
                Data = result
            });
        }
        [HttpGet("sql/GetPaging")]
        public async Task<IActionResult> GetPaging(int index, int size)
        {
            var query = new GetPagingMemberShipTypesQuery(index, size);

            var result = await Sender.Send(query);
            if (result != null)
            {
                if (result.Any())
                    return Ok(new ResponseWithListSuccess<MemberShipTypeResposeDto>
                    {
                        Message = "Tìm thấy thành công",
                        ListData = result
                    });
                return Ok(new ResponseWithListSuccess<MemberShipTypeResposeDto>
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
            var query = new GetTotalPagingMemberShipTypesQuery(size);

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
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMemberShipTypeRequest entity)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
            var command = new CreateMemberShipTypeCommand(entity,userId);
            var result = await Sender.Send(command);
            if (result!=null)
                return Ok(new ResponseSuccess()
                {
                    Message = $"Tạo thành công!!!{result}"
                });
            return BadRequest(new ResponseFailure()
            {
                Message = "Tạo không thành công!!!"
            });
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateMemberShipTypeRequest entity, Guid id)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
            var command = new UpdateMemberShipTypeCommand(entity, userId);
            var result = await Sender.Send(command);
            if (result != null)
                return Ok(new ResponseSuccess()
                {
                    Message = $"Sửa thành công {result}!!!"
                });
            return BadRequest(new ResponseFailure()
            {
                Message = "Sửa thất bại!!!"
            });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteMemberShipTypeRequest deleteMemberShipTypeRequest)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
            var command = new DeleteMemberShipTypeCommand(deleteMemberShipTypeRequest, userId);
            var result = await Sender.Send(command);
            if (result != null)
                return Ok(new ResponseSuccess()
                {
                    Message = $"Xoá thành công{result} ",
                });
            return BadRequest(new ResponseFailure()
            {
                Message = "Xoá thất bại"
            });
        }
    }
}

using System.Drawing;
using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.ModelResponses;
using Supermarket.Application.Services.Attribute.Commands.CreateAttribute;
using Supermarket.Application.Services.Attribute.Commands.DeleteAttribute;
using Supermarket.Application.Services.Attribute.Commands.UpdateAttribute;
using Supermarket.Application.Services.Attribute.Queries.SQLServerQueries.GetAllAttributes;
using Supermarket.Application.Services.Attribute.Queries.SQLServerQueries.GetAttributeById;
using Supermarket.Application.Services.Attribute.Queries.SQLServerQueries.GetPagingAttributes;
using Supermarket.Application.Services.Attribute.Queries.SQLServerQueries.GetTotalPagingAttributes;

namespace Supermarket.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]

[Authorize]
public class AttributeController : ApiController
{
    [HttpGet("sql")]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllAttributeQuery();
        var result = await Sender.Send(query,cancellationToken);
        if (result != null)
        {
            if (result.Any())
                return Ok(new ResponseWithListSuccess<AttributeResponseDto>
                {
                    Message = "Tìm thấy thành công",
                    ListData = result
                });
            return Ok(new ResponseWithListSuccess<AttributeResponseDto>
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
        var query = new GetPagingAttributeQuery(index,size);
        var result = await Sender.Send(query);
        if (result != null)
        {
            if (result.Any())
                return Ok(new ResponseWithListSuccess<AttributeResponseDto>
                {
                    Message = "Tìm thấy thành công",
                    ListData = result
                });
            return Ok(new ResponseWithListSuccess<AttributeResponseDto>
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
        var query = new GetTotalPagingAttributeQuery(size);
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
        var query = new GetAttributeByIdQuery(id);
        var result = await Sender.Send(query);

        if (result != null)
            return Ok(new ResponseWithDataSuccess<AttributeResponseDto>
            {
                Message = "Tìm thấy thông tin",
                Data = result
            });
        return BadRequest(new ResponseWithDataFailure<AttributeResponseDto>
        {
            Message = "Không tìm thấy thông tin",
            Data = result
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAttributeRequest attributeDto)
    {
        var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
        var command = new CreateAttributeCommand(attributeDto, userId);
        var result = await Sender.Send(command);
        if (result!=null)
            return Ok(new ResponseWithDataSuccess<Guid?>()
            {
                Message = "Tạo thành công!!!",
                Data = result
            });
        return BadRequest(new ResponseFailure()
        {
            Message = "Tạo không thành công!!!"
        });
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateAttributeRequest attributeDto)
    {
        var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
        var command = new UpdateAttributeCommand(attributeDto, userId);
    var result = await Sender.Send(command);
        if (result!=null)
            return Ok(new ResponseWithDataSuccess<Guid?>()
            {
                Message = "Sửa thành công!!!",
                Data = result
            });
        return BadRequest(new ResponseFailure()
        {
            Message = "Sửa thất bại!!!"
        });
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteAttributeRequest deleteAttributeRequest)
    {
        var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
        var command = new DeleteAttributeCommand(deleteAttributeRequest, userId);
        var result = await Sender.Send(command);
        if (result != null)
            return Ok(new ResponseWithDataSuccess<Guid?>()
            {
                Message = "Xoá thành công",
                Data = result
            });
        return BadRequest(new ResponseFailure()
        {
            Message = "Xoá thất bại"
        });
    }
}
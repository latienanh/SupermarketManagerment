using Microsoft.AspNetCore.Mvc;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.IServices;
using Supermarket.Application.ModelResponses;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Supermarket.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryServices _categoryServices;
    private readonly IImageServices _imageServices;

    public CategoriesController(ICategoryServices categoryServices,IImageServices _imageServices)
    {
        _categoryServices = categoryServices;
        this._imageServices = _imageServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _categoryServices.GetAllAsync();
        if (result != null)
        {
            if (result.Any())
                return Ok(new ResponseWithListSuccess<CategoryResponseDto>
                {
                    Message = "Tìm thấy thành công",
                    ListData = result
                });
            return Ok(new ResponseWithListSuccess<CategoryResponseDto>
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
    public async Task<IActionResult> GetPaging( int index, int size)
    {
        var result = await _categoryServices.getPagingAsync( index, size);
        if (result != null)
        {
            if (result.Any())
                return Ok(new ResponseWithListSuccess<CategoriesPagingResponseDto>
                {
                    Message = "Tìm thấy thành công",
                    ListData = result
                });
            return Ok(new ResponseWithListSuccess<CategoriesPagingResponseDto>
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
    public async Task<IActionResult> GetTotalPaging( int size)
    {
        var result = await _categoryServices.getTotalPagingTask(size);
        if (result != null)
        {
            if(result>0)
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
        var result = await _categoryServices.GetByIdAsync(id);
        if (result != null)
            return Ok(new ResponseWithDataSuccess<CategoryResponseDto>
            {
                Message = "Tìm thấy thông tin",
                Data = result
            });
        return BadRequest(new ResponseWithDataFailure<CategoryResponseDto>
        {
            Message = "Không tìm thấy thông tin",
            Data = result
        });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CategoryRequestDto model)
    {
        var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
        var folderCategory = "images/categories/";

            var categoryImagePath = await _imageServices.SaveImageAsync(folderCategory, model.Image);
            if (categoryImagePath == null)
            {
                model.PathImage = "/images/default-image.jpg";
            }
            else if (!categoryImagePath.isSuccess)
            {
                return BadRequest(new ResponseFailure()
                {
                    Message = categoryImagePath.Message,
                });
            }
            else
            {
                model.PathImage = categoryImagePath.Data;
            }
            
        var result = await _categoryServices.CreateAsync(model, userId);
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
        var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
        var result = await _categoryServices.DeleteAsync(id, userId);
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
    public async Task<IActionResult> Update(Guid id,[FromForm] CategoryRequestDto model)
    {
        var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
        var folderCategory = "images/categories/";

       
            var categoryImagePath = await _imageServices.SaveImageAsync(folderCategory, model.Image);
            if (categoryImagePath == null)
            {
                model.PathImage = null;
            }
            else if(!categoryImagePath.isSuccess)
            {
                return BadRequest(new ResponseFailure()
                {
                    Message = categoryImagePath.Message
                });
            }
            else
            {
                     model.PathImage = categoryImagePath.Data;
            }
            
        var result = await _categoryServices.UpdateAsync(model, id, userId);
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
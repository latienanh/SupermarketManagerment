using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.ModelResponses;
using Supermarket.Application.Services.Coupon.Commands.CreateCoupon;
using Supermarket.Application.Services.Coupon.Commands.DeleteCoupon;
using Supermarket.Application.Services.Coupon.Commands.UpdateCoupon;
using Supermarket.Application.Services.Coupon.Queries.SQLServerQueries.GetAllCoupons;
using Supermarket.Application.Services.Coupon.Queries.SQLServerQueries.GetCouponById;
using Supermarket.Application.Services.Coupon.Queries.SQLServerQueries.GetPagingCoupons;
using Supermarket.Application.Services.Coupon.Queries.SQLServerQueries.GetTotalPagingCoupons;

namespace Supermarket.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CouponController : ApiController
    {


        [HttpGet("sql")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllCouponsQuery();

            var result = await Sender.Send(query);
            if (result != null)
            {
                if (result.Any())
                    return Ok(new ResponseWithListSuccess<CouponResposeDto>
                    {
                        Message = "Tìm thấy thành công",
                        ListData = result
                    });
                return Ok(new ResponseWithListSuccess<CouponResposeDto>
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
            var query = new GetCouponByIdQuery(id);

            var result = await Sender.Send(query);
            if (result != null)
                return Ok(new ResponseWithDataSuccess<CouponResposeDto>
                {
                    Message = "Tìm thấy thông tin",
                    Data = result
                });
            return BadRequest(new ResponseWithDataFailure<CouponResposeDto>
            {
                Message = "Không tìm thấy thông tin",
                Data = result
            });
        }
      
        [HttpGet("sql/GetPaging")]
        public async Task<IActionResult> GetPaging(int index, int size)
        {
            var query = new GetPagingCouponsQuery(index,size);

            var result = await Sender.Send(query);
            if (result != null)
            {
                if (result.Any())
                    return Ok(new ResponseWithListSuccess<CouponResposeDto>
                    {
                        Message = "Tìm thấy thành công",
                        ListData = result
                    });
                return Ok(new ResponseWithListSuccess<CouponResposeDto>
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
            var query = new GetTotalPagingCouponsQuery(size);

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
        public async Task<IActionResult> Create([FromBody] CreateCouponRequest model)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
            var command = new CreateCouponCommand(model, userId);
            var result = await Sender.Send(command);
            if (result != null)
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

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteCouponRequest deleteCouponRequest)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
            var command = new DeleteCouponCommand(deleteCouponRequest, userId);
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
        [HttpPut]
        public async Task<IActionResult> Update( UpdateCouponRequest model)
        {
            var userId = Guid.Parse(HttpContext.User.FindFirstValue("userId"));
            var command = new UpdateCouponCommand(model, userId);
            var result = await Sender.Send(command);
            if (result != null)
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
    }
}


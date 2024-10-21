using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Application.Abstractions.IImageservices;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.ModelResponses;
using Supermarket.Application.Services.Product.Commands.CreateProduct;
using Supermarket.Application.Services.Product.Commands.DeleteProduct;
using Supermarket.Application.Services.Product.Commands.UpdateProduct;
using Supermarket.Application.Services.Product.Queries.SQLServerQueries.GeProductById;
using Supermarket.Application.Services.Product.Queries.SQLServerQueries.GetAllProducts;
using Supermarket.Application.Services.Product.Queries.SQLServerQueries.GetPagingProducts;
using Supermarket.Application.Services.Product.Queries.SQLServerQueries.GetTotalPagingProducts;


namespace Supermarket.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ApiController
    {

        private readonly IImageServices _imageServices;

        public ProductController(IImageServices imageServices)
        {
            _imageServices = imageServices;
        }

        [HttpGet("sql")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllProductsQuery();
            var result = await Sender.Send(query, cancellationToken);
            if (result != null)
            {
                if (result.Any())
                    return Ok(new ResponseWithListSuccess<ProductResponseDto>
                    {
                        Message = "Tìm thấy thành công",
                        ListData = result
                    });
                return Ok(new ResponseWithListSuccess<ProductResponseDto>
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
            var query = new GetPagingProductsQuery(index,size);

            var result = await Sender.Send(query);
            if (result != null)
            {
                if (result.Any())
                    return Ok(new ResponseWithListSuccess<ProductsPagingResponseDto>
                    {
                        Message = "Tìm thấy thành công",
                        ListData = result
                    });
                return Ok(new ResponseWithListSuccess<ProductsPagingResponseDto>
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
            var query = new GetTotalPagingProductsQuery(size);

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
            var query = new GetProductByIdQuery(id);

            var result = await Sender.Send(query);
            if (result != null)
                return Ok(new ResponseWithDataSuccess<ProductResponseDto>
                {
                    Message = "Tìm thấy thông tin",
                    Data = result
                });
            return BadRequest(new ResponseWithDataFailure<ProductResponseDto>
            {
                Message = "Không tìm thấy thông tin",
                Data = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateProductRequest createProductRequest,CancellationToken cancellationToken)
        {
            var folderProduct = "images/products/";
            var productImagePath = await _imageServices.SaveImageAsync(folderProduct, createProductRequest.Image);
            if (productImagePath == null)
            {
                createProductRequest.PathImage = "/images/default-image.jpg";
            }
            else if (!productImagePath.isSuccess)
            {
                return BadRequest(new ResponseFailure()
                {
                    Message = productImagePath.Message,
                });
            }
            else
            {
                createProductRequest.PathImage = productImagePath.Data;
            }


            if (createProductRequest.Variants != null)
            {
                foreach (var variant in createProductRequest.Variants)
                {
                    var variantImagePath = await _imageServices.SaveImageAsync(folderProduct, variant.Image);
                    if (variantImagePath == null)
                    {
                        variant.PathImage = "/images/default-image.jpg";
                    }
                    else if (!variantImagePath.isSuccess)
                    {
                        return BadRequest(new ResponseFailure()
                        {
                            Message = variantImagePath.Message,
                        });
                    }
                    else
                    {
                        variant.PathImage = variantImagePath.Data;
                    }
                }
            }

            var userId = new Guid(HttpContext.User.FindFirstValue("userId"));
            var command = new CreateProductCommand(createProductRequest, userId);
            var productCreate =  await Sender.Send(command,cancellationToken);
            if (productCreate!=null)
                return Ok(new ResponseSuccess()
                {
                    Message = $"Tạo thành công!!!{productCreate}"
                });
            return BadRequest(new ResponseFailure()
            {
                Message = "Tạo không thành công!!!"
            });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteProductRequest deleteProductRequest , CancellationToken cancellationToken)
        {
            var userId = new Guid(HttpContext.User.FindFirstValue("userId"));
            var command = new DeleteProductCommand(deleteProductRequest,userId);
            var result = await Sender.Send(command,cancellationToken);
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
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateProductRequest model,CancellationToken cancellationToken)
        {
            var folderProduct = "images/products/";
            var productImagePath = await _imageServices.SaveImageAsync(folderProduct, model.Image);
            if (productImagePath == null)
            {
                model.PathImage = null;
            }
            else if (!productImagePath.isSuccess)
            {
                return BadRequest(new ResponseFailure()
                {
                    Message = productImagePath.Message,
                });
            }
            else
            {
                model.PathImage = productImagePath.Data;
            }
            var userId = new Guid(HttpContext.User.FindFirstValue("userId"));
            var command = new UpdateProductCommand(model, userId);
            var result = await Sender.Send(command, cancellationToken);
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

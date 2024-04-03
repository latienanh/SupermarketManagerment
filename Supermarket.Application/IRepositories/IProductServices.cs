using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.IServices;

namespace Supermarket.Application.IRepositories
{
    public interface IProductServices : IServicesBase<ProductRequestDto,ProductResponseDto>
    {
    }
}

using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Application.IServices
{
    public interface IRoleServices : IServicesBase<RoleRequestDto,RoleResponseDto>
    {
    }
}

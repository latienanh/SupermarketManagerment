using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Supermarket.Application.DTOs;
using Supermarket.Application.DTOs.Auth;
using Supermarket.Application.DTOs.SupermarketDtos;
using Supermarket.Domain.Entities.Identity;
using Supermarket.Domain.Entities.SupermarketEntities;
using Attribute = Supermarket.Domain.Entities.SupermarketEntities.Attribute;

namespace Supermarket.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<AppUser, SignUpDtos>().ReverseMap();
            CreateMap<Attribute,AttributeDto>().ReverseMap();
        }
    }
}

using AutoMapper;
using Supermarket.Application.DTOs.SupermarketDtos.RequestDtos;
using Supermarket.Domain.Entities.Common;

namespace Supermarket.Application.Mapper;

public class ModificationMapper : Profile
{
    public ModificationMapper()
    {
        CreateMap<Modification, ModificationDto>().ReverseMap();
    }
}
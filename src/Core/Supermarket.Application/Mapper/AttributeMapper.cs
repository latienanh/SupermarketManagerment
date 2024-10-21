using AutoMapper;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.Services.Attribute.Commands.CreateAttribute;
using Supermarket.Application.Services.Attribute.Commands.UpdateAttribute;
using Attribute = Supermarket.Domain.Entities.SupermarketEntities.Attribute;

namespace Supermarket.Application.Mapper;

public class AttributeMapper : Profile
{
    public AttributeMapper()
    {
        CreateMap<Attribute, AttributeResponseDto>().ReverseMap();
        CreateMap<Attribute, CreateAttributeRequest>().ReverseMap();
        CreateMap<Attribute, UpdateAttributeRequest>().ReverseMap();
    }
}
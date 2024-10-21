using AutoMapper;
using Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos;
using Supermarket.Application.Services.Attribute.Commands.UpdateAttribute;
using Supermarket.Application.Services.MemberShipType.Commands.CreateMemberShipType;
using Supermarket.Domain.Entities.SupermarketEntities;

namespace Supermarket.Application.Mapper;

public class MemberShipTypeMapper : Profile
{
    public MemberShipTypeMapper()
    {
        CreateMap<MemberShipType, CreateMemberShipTypeRequest>().ReverseMap();
        CreateMap<MemberShipType, UpdateAttributeRequest>().ReverseMap();
        CreateMap<MemberShipType, MemberShipTypeResposeDto>().ReverseMap();
    }
}
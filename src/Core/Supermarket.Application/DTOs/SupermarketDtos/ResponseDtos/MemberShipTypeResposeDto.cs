using Supermarket.Application.Common;

namespace Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos
{
    public sealed record MemberShipTypeResposeDto :BaseDTOResponse
    { 
        public string? Name { get; set; }
    }
}

using Supermarket.Application.Common;

namespace Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos
{
    public sealed record AttributeResponseDto : BaseDTOResponse
    {
        public string? Name { get; set; }
    }
}

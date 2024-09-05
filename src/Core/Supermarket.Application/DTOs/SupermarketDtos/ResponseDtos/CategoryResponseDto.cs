using Supermarket.Application.Common;

namespace Supermarket.Application.DTOs.SupermarketDtos.ResponseDtos
{
    public sealed record CategoryResponseDto:BaseDTOResponse
    {
        public Guid? ParentId { get; set; }
        public string? Name { get; set; }
        public string? Describe { get; set; }
        public string Image { get; set; }
    }
}

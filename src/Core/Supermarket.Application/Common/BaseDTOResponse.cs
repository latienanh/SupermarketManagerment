namespace Supermarket.Application.Common;

public record BaseDTOResponse
{
    public Guid Id { get; set; }
    public Guid? CreateBy { get; set; }
    public DateTime CreateTime { get; set; }
}


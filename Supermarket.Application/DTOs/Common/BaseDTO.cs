namespace Supermarket.Application.DTOs.Common;

public class BaseDTO
{
    public Guid id { get; set; }
    public Guid? CreateBy { get; set; }
    public DateTime CreateTime { get; set; }
}
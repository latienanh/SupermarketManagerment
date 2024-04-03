namespace Supermarket.Application.DTOs.Common;

public class BaseDTO
{
    public int id { get; set; }
    public int? CreateBy { get; set; }
    public DateTime CreateTime { get; set; }
}
namespace Supermarket.Application.DTOs.Common;

public class BaseDTO
{
    public bool? IsDelete { get; set; }
    public int? CreateBy { get; set; }
    public DateTime CreateTime { get; set; }
    public int? ModifiedBy { get; set; }
    public DateTime ModifiedTime { get; set; }
    public int? DeleteBy { get; set; }
}
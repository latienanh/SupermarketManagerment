using Supermarket.Domain.Entities.Common;
using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Domain.Entities.SupermarketEntities;

public class Employee 
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? FullName { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public int UserId { get; set; }
    public AppUser AppUser { get; set; }
}
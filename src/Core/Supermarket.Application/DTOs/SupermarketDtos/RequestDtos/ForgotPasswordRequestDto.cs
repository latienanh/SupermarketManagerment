
using System.ComponentModel.DataAnnotations;


namespace Supermarket.Application.DTOs.SupermarketDtos.RequestDtos
{
    public class ForgotPasswordRequestDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

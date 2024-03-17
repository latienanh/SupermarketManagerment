using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Domain.Entities.Token
{
    public class RefreshToken
    {
        public int Id { get; set; } 
        public string Token { get; set; }
        public DateTime Expriaton { get; set; }
        public int UserId { get; set; }
        public AppUser AppUser { get;  }
    }
}

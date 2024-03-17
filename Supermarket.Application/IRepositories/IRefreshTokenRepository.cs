using Supermarket.Domain.Entities.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Application.ModelResponses;

namespace Supermarket.Application.IRepositories
{
    public  interface IRefreshTokenRepository
    {
        Task<bool> ValidateRefreshTokenAsync(string token);
        Task<RefreshToken> CreateRefreshTokenAsync(RefreshToken refreshToken);
        Task<RefreshToken> UpdateRefreshTokenAsync(RefreshToken refreshToken);
    }
}

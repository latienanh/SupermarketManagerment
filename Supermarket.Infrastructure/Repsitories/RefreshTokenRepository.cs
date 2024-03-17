using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.Application.IRepositories;
using Supermarket.Application.ModelResponses;
using Supermarket.Domain.Entities.Token;
using Supermarket.Infastructure;

namespace Supermarket.Infrastructure.Repsitories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly SuperMarketDbContext _superMarketDbContext;

        public RefreshTokenRepository(SuperMarketDbContext superMarketDbContext)
        {
            _superMarketDbContext = superMarketDbContext;
        }
        public async Task<RefreshToken> CreateRefreshTokenAsync(RefreshToken refreshToken)
        {
            await _superMarketDbContext.RefreshTokens.AddAsync(refreshToken);
            await _superMarketDbContext.SaveChangesAsync();
            return refreshToken;
        }

        public async Task<RefreshToken> UpdateRefreshTokenAsync(RefreshToken refreshToken)
        {
            var updateRefeshToken =
                await _superMarketDbContext.RefreshTokens.FirstOrDefaultAsync(m => m.UserId == refreshToken.UserId);
            if (updateRefeshToken!= null)
            {
                updateRefeshToken.Token=refreshToken.Token;
                updateRefeshToken.Expriaton=refreshToken.Expriaton;
                await _superMarketDbContext.SaveChangesAsync();
                return refreshToken;
            }

            return null;
        }

        public async Task<bool> ValidateRefreshTokenAsync(string token)
        {
            throw new NotImplementedException();
        }
    }
}

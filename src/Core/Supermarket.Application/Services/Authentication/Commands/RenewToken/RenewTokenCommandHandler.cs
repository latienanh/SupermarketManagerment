using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Supermarket.Application.Abstractions.Messaging;
using Supermarket.Application.Abstractions.Token;
using Supermarket.Application.Services.Authentication.Commands.Login;
using Supermarket.Application.Settings;
using Supermarket.Domain.Abstractions.IRepositories;
using Supermarket.Domain.Abstractions.IUnitOfWorks;
using Supermarket.Domain.Entities.Identity;

namespace Supermarket.Application.Services.Authentication.Commands.RenewToken
{
    public sealed class RenewTokenCommandHandler : ICommandHandler<RenewTokenCommand, LoginResponse?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JsonWebTokenSetting _jsonWebTokenSetting;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUserRepository<AppUser> _userRepository;
        private readonly ITokenQuery _tokenQuery;
        private readonly IMapper _mapper;
   

        public RenewTokenCommandHandler(IUnitOfWork unitOfWork,JsonWebTokenSetting jsonWebTokenSetting,IRefreshTokenRepository refreshTokenRepository,IUserRepository<AppUser> userRepository,ITokenQuery tokenQuery)
        {
            _unitOfWork = unitOfWork;
            _jsonWebTokenSetting = jsonWebTokenSetting;
            _refreshTokenRepository = refreshTokenRepository;
            _userRepository = userRepository;
            _tokenQuery = tokenQuery;
        }
        private DateTime ConvertUtcTime(long utcTime)
        {
            var dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeInterval = dateTimeInterval.AddSeconds(utcTime).ToUniversalTime();
            return dateTimeInterval;
        }
        public async Task<LoginResponse?> Handle(RenewTokenCommand request, CancellationToken cancellationToken)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_jsonWebTokenSetting.SecretKey);
            var param = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = _jsonWebTokenSetting.ValidIssuer,
                ValidAudience = _jsonWebTokenSetting.ValidAudience,
                IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
                ClockSkew = new TimeSpan(0, 0, 5),
                ValidateLifetime = false
            };
            try
            {
                //check 1 :AccessToken Validate 
                var tokenInVerification =
                    jwtTokenHandler.ValidateToken(request.RenewTokenRequest.AccessToken, param, out var validatedToken);
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    //check 2 : kiem tra ma hoa
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                        StringComparison.InvariantCultureIgnoreCase);
                    if (!result) return null;
                }

                //check 3 : check han accesstoken
                var utcExpireDate = long.Parse(tokenInVerification.Claims
                    .FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
                var expriceDate = ConvertUtcTime(utcExpireDate);
                if (expriceDate > DateTime.UtcNow) return null;

                //check 4 : Refesh co ton tai khong
                var storeRefeshToken = await _refreshTokenRepository.GetByTokenAsync(request.RenewTokenRequest.RefreshToken);
        
                if (storeRefeshToken is null)
                {
                    return null;
                }

                if (storeRefeshToken.Expriaton < DateTime.UtcNow)
                    return null;
                var user = await _userRepository.GetByIdAsync(storeRefeshToken.UserId);
                var token = await _tokenQuery.GenerateAccessTokenAsync(user);
                var AccessToken = new JwtSecurityTokenHandler().WriteToken(token);
                return new LoginResponse()
                {
                    AccessToken = AccessToken,
                    RefreshToken = storeRefeshToken.Token,
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }
    }
}
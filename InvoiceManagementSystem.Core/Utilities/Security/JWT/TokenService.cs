using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace InvoiceManagementSystem.Core.Utilities.Security.JWT
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration Configuration;
        private readonly DateTime tokenExpireDate = DateTime.Now.AddMinutes(15);

        public TokenService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public AccessToken CreateAccessToken(List<Claim> claims)
        {
            var securityKey = Configuration.GetSection("JwtOptions:SecurityKey").Value;
            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey!));
            var signinCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha512);


            var jwtToken = new JwtSecurityToken(
                issuer: Configuration.GetSection("JwtOptions:Issuer").Value,
                audience: Configuration.GetSection("JwtOptions:Audience").Value,
                signingCredentials: signinCredentials,
                expires: tokenExpireDate,
                notBefore: DateTime.Now,
                claims: claims
                );
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(jwtToken);

            var accessToken = new AccessToken
            {
                Token = token,
                ExpireTime = tokenExpireDate
            };

            return accessToken;
        }

        public RefreshToken CreateRefreshToken()
        {
            var random = RandomNumberGenerator.GetBytes(32);
            var refreshToken = Convert.ToBase64String(random);
            return new RefreshToken
            {
                Token = refreshToken,
                ExpireDate = tokenExpireDate.AddMinutes(1)
            };
        }
    }
}

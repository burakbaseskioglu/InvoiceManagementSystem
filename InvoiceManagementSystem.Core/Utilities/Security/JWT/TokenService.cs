using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace InvoiceManagementSystem.Core.Utilities.Security.JWT
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration Configuration;

        public TokenService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public AccessToken CreateAccessToken()
        {
            var tokenExpireTime = DateTime.Now.AddMinutes(30);
            var securityKey = Configuration.GetSection("JwtOptions:SecurityKey").Value;
            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey!));
            var signinCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha512);
            var jwtToken = new JwtSecurityToken(
                issuer: Configuration.GetSection("JwtOptions:Issuer").Value,
                audience: Configuration.GetSection("JwtOptions:Audience").Value,
                signingCredentials: signinCredentials,
                expires: tokenExpireTime,
                notBefore: DateTime.Now
                );
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(jwtToken);

            var accessToken = new AccessToken
            {
                Token = token,
                ExpireTime = tokenExpireTime
            };

            return accessToken;
        }
    }
}

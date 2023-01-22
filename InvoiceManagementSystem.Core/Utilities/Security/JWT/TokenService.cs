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

        //public string CreateAccessToken()
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("JwtTokenOptions:SecurityKey").ToString()));
        //    var signInCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        SigningCredentials = signInCredentials,
        //        Expires = DateTime.Now.AddMinutes(30)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    return tokenHandler.WriteToken(token);
        //}

        public string CreateAccessToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("JwtTokenOptions:SecurityKey").ToString()));
            var signInCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
            var jwtToken = new JwtSecurityToken(
                issuer: Configuration.GetSection("").ToString(),
                audience: Configuration.GetSection("").ToString(),
                expires: DateTime.Now.AddMinutes(30),
                notBefore: DateTime.Now,
                signingCredentials: signInCredentials
                );
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(jwtToken);
            return token;
        }
    }
}

﻿using GoodWill.Domain.Entities;
using GoodWill.Domain.Security.Token;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GoodWill.Infrastructure.Security.Token
{
    public class JwtTokenGenerator : IAccessTokenGenerator
    {
        private readonly uint _expirationTimeMinutes;
        private readonly string _signInKey;
        public JwtTokenGenerator(uint expirationTimeMinutes, string signInKey)
        {
            _expirationTimeMinutes = expirationTimeMinutes;
            _signInKey = signInKey;
        }
        public string GenerateToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Sid, user.UserId.ToString()),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(_expirationTimeMinutes),
                SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }
        private SymmetricSecurityKey SecurityKey()
        {
            var key = Encoding.UTF8.GetBytes(_signInKey);

            return new SymmetricSecurityKey(key);
        }
    }
}

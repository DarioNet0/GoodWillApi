﻿using GoodWill.Domain.Entities;
using GoodWill.Domain.Security.Token;
using GoodWill.Domain.Services.LoggedUsers;
using GoodWill.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GoodWill.Infrastructure.Services
{
    internal class LoggedUsers : ILoggedUsers
    {
        private readonly GoodWillDbContext _dbContext;
        private readonly ITokenProvider _tokenProvider;

        public LoggedUsers(GoodWillDbContext dbContext, ITokenProvider tokenProvider)
        {
            _dbContext = dbContext;
            _tokenProvider = tokenProvider;
        }

        public async Task<User> Get()
        {
            string token = _tokenProvider.TokenOnRequest();

            var tokenHandler = new JwtSecurityTokenHandler();

            var jwtSecurityToken = tokenHandler.ReadJwtToken(token);

            var sidClaim = jwtSecurityToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value;

            Console.WriteLine($"Claim sid value: {sidClaim}");

            if (string.IsNullOrEmpty(sidClaim))
                throw new Exception("Claim sid não encontrado no token.");

            if (!long.TryParse(sidClaim, out long userId))
                throw new Exception($"Claim sid '{sidClaim}' não é um número válido.");

            var identifier = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value;

            return await _dbContext
                .Users
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.UserId == long.Parse(identifier));
        }
    }
}

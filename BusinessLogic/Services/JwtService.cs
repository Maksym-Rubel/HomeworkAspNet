using BusinessLogic.Interface;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration configuration;
        private readonly UserManager<User> userManager;
        private readonly JwtOptions jwtOptions;
        private readonly RandomNumberGenerator rng = RandomNumberGenerator.Create();
        public JwtService(IConfiguration configuration, UserManager<User> userManager, JwtOptions jwtOptions)
        {
            this.configuration = configuration;
            this.userManager = userManager;
            this.jwtOptions = jwtOptions;
           
        }


        public string GenerateToken(IEnumerable<Claim> claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
                issuer: jwtOptions.Issuer,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(jwtOptions.Lifetime),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

            public  async Task<IEnumerable<Claim>> GetClaims(User user)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Id),
                    new Claim(ClaimTypes.Email,user.Email),

                };

            var roles = await userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));

            return claims;
        }


        public RefreshToken GenerateRefreshToken(string ipAddress)
        {


            var randomBytes = new byte[64];
            rng.GetBytes(randomBytes);

            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomBytes),
                Expired = DateTime.UtcNow.AddDays(jwtOptions.RefreshTokenExpirationDays),
                CreatedByIp = ipAddress
            };



        }


    }


    public class JwtOptions
    {
        public string Key { get; set; }
        public int Lifetime { get; set; }
        public string Issuer { get; set; }
        
        public int RefreshTokenExpirationDays { get; set; }

    }
}

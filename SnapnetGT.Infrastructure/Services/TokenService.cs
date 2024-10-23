using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SnapnetGT.Data.Entities;
using SnapnetGT.Infrastructure.Interface.Service;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SnapnetGT.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(User user)
        {
            //Create list of claims
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("FirstName",user.FirstName),
                new Claim("LastName",user.LastName)
            };


            //Prepare token expiration
            var expiration = DateTime.Now.AddMinutes(
                Convert.ToInt32(_configuration["Authentication:JwtBearer:AccessExpiration"]
                ));

            //Create the sign in key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:JwtBearer:SecretKey"]));

            //Create the sign in credentials
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);



            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration["Authentication:JwtBearer:Issuer"],
                audience: _configuration["Authentication:JwtBearer:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: cred
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}

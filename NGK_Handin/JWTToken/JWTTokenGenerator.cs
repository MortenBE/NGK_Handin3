
using System;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NGK_Handin3.JWTToken
{
    public class JWTTokenGenerator
    {
        private string GenerateToken(string Email, bool IsWeatherStation)
        {
            Claim roleClaim;
            if (IsWeatherStation)
                roleClaim = new Claim(ClaimTypes.Role, "WeatherStation");
            else
                roleClaim = new Claim(ClaimTypes.Role, "Bruger");

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Email, Email),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
            };

            var token = new JwtSecurityToken(
                 new JwtHeader(new SigningCredentials(
                      new SymmetricSecurityKey(Encoding.UTF8.GetBytes("RQIN0XQfSYQGCoi")),
                      SecurityAlgorithms.HmacSha256Signature)),
                      new JwtPayload(claims));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
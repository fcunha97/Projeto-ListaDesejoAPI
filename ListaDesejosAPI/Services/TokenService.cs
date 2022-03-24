using ListaDesejosAPI.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;

namespace ListaDesejosAPI.Services
{
    public static class TokenService
    {
        public static string GenerateToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            byte[]key = Encoding.ASCII.GetBytes(Settings.Secrete);
            var tokenDescriptor = new SecurityTokenDescriptor {
           
                   Subject = new ClaimsIdentity (new[] { 
                   
                       new Claim(ClaimTypes.Name, usuario.Login),
                       new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString())
                        
                   }),
                    Expires = DateTime.UtcNow.AddHours(2),
                    SigningCredentials = 
                    new SigningCredentials(
                        new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };
           var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
    
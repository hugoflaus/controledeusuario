using System;
using System.Text;
using System.Security.Cryptography;
using System.Security.Claims;
using System.Threading.Tasks;
using GestaoAcesso.Core.Models;
using GestaoAcesso.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace GestaoAcesso.Infrastructure.AuthServices
{
    public class AuthService : IAuthService
    {
        public Token CreateToken(IdentityUser<int> usuario, string role)
        {
            Claim[] direitoUsuario = new Claim[]
            {
                new Claim("username", usuario.UserName),
                new Claim("id", usuario.Id.ToString()),
                new Claim(ClaimTypes.Role, role)
            };

            var chave = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("kldjhfsdfsdfsvjvkfdfkjfsdmnfjcxhvjfhfdhskfjdsh")
            );

            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: direitoUsuario,
                signingCredentials: credenciais,
                expires: DateTime.UtcNow.AddHours(1)
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new Token(tokenString);
        }
    }
}
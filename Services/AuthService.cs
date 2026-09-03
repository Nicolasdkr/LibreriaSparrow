using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using LibreriaSparrow.Api.Data;
using LibreriaSparrow.Api.DTOs;
using LibreriaSparrow.Api.Models;

namespace LibreriaSparrow.Api.Services;

public class AuthService(LibreriaContext context, IConfiguration configuration) : IAuthService
{
    public async Task<string?> LoginAsync(LoginDto dto)
    {
        var usuario = await context.Usuarios
            .FirstOrDefaultAsync(u => u.Username == dto.Username);

        if (usuario is null) return null;

        var hasher = new PasswordHasher<Usuario>();
        var resultado = hasher.VerifyHashedPassword(usuario, usuario.PasswordHash, dto.Password);

        return resultado == PasswordVerificationResult.Failed
            ? null
            : GenerarToken(usuario);
    }

    private string GenerarToken(Usuario usuario)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, usuario.Username),
            new Claim(ClaimTypes.Role, usuario.Rol)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(4),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
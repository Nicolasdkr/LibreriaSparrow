using Microsoft.AspNetCore.Mvc;
using LibreriaSparrow.Api.DTOs;
using LibreriaSparrow.Api.Services;

namespace LibreriaSparrow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var token = await authService.LoginAsync(dto);
        return token is null ? Unauthorized("Usuario o contraseña incorrectos.") : Ok(new { token });
    }
}
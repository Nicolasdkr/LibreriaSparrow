using LibreriaSparrow.Api.DTOs;

namespace LibreriaSparrow.Api.Services;

public interface IAuthService
{
    Task<string?> LoginAsync(LoginDto dto);
}
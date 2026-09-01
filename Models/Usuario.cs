namespace LibreriaSparrow.Api.Models;

public class Usuario
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
    public string Rol { get; set; } = "Admin";
}
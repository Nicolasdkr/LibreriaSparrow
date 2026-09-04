namespace LibreriaSparrow.Api.DTOs;

public class ClienteDto
{
	public int Id { get; set; }
	public string Nombre { get; set; } = string.Empty;
	public string Rut { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public string? Telefono { get; set; }
	public string? Direccion { get; set; }
	public DateTime? FechaNacimiento { get; set; }
	public DateTime FechaRegistro { get; set; }
}
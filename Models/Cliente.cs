namespace LibreriaSparrow.Api.Models;

public class Cliente
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public string Rut { get; set; }
    public string Email { get; set; }
    public string? Telefono { get; set; }
    public string? Direccion { get; set; }
    public DateTime? FechaNacimiento { get; set; }
    public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;

    public List<Pedido> Pedidos { get; set; } = [];
}
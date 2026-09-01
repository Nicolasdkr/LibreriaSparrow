// Models/Libro.cs
namespace LibreriaSparrow.Api.Models;

public class Libro
{
    public int Id { get; set; }
    public required string Titulo { get; set; }
    public required string Autor { get; set; }
    public string? Descripcion { get; set; }
    public required string Categoria { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public required string Estado { get; set; } = "Disponible";
    public string? ImagenUrl { get; set; }

    public int ProveedorId { get; set; }
    public Proveedor? Proveedor { get; set; }

    public List<DetallePedido> DetallesPedido { get; set; } = [];
}
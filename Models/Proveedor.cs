namespace LibreriaSparrow.Api.Models;

public class Proveedor
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string? Contacto { get; set; }
    public string? Telefono { get; set; }

    public List<Libro> Libros { get; set; } = [];

}
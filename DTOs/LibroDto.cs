namespace LibreriaSparrow.Api.DTOs;

public class LibroDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public string Categoria { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public string Estado { get; set; } = string.Empty;
    public string? ImagenUrl { get; set; }
    public int ProveedorId { get; set; }
    public string? ProveedorNombre { get; set; }
}
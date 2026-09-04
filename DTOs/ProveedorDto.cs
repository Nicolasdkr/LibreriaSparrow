namespace LibreriaSparrow.Api.DTOs;

public class ProveedorDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Contacto { get; set; }
    public string? Telefono { get; set; }
    public List<LibroResumenDto> Libros { get; set; } = [];
}

public class LibroResumenDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
}
using LibreriaSparrow.Api.DTOs;
using LibreriaSparrow.Api.Models;

namespace LibreriaSparrow.Api.Mappers;

public static class DtoMappers
{
    public static LibroDto ToDto(this Libro libro) => new()
    {
        Id = libro.Id,
        Titulo = libro.Titulo,
        Autor = libro.Autor,
        Descripcion = libro.Descripcion,
        Categoria = libro.Categoria,
        Precio = libro.Precio,
        Stock = libro.Stock,
        Estado = libro.Estado,
        ImagenUrl = libro.ImagenUrl,
        ProveedorId = libro.ProveedorId,
        ProveedorNombre = libro.Proveedor?.Nombre
    };

    public static ProveedorDto ToDto(this Proveedor proveedor) => new()
    {
        Id = proveedor.Id,
        Nombre = proveedor.Nombre,
        Contacto = proveedor.Contacto,
        Telefono = proveedor.Telefono,
        Libros = proveedor.Libros
            .Select(l => new LibroResumenDto { Id = l.Id, Titulo = l.Titulo })
            .ToList()
    };

    public static ClienteDto ToDto(this Cliente cliente) => new()
    {
        Id = cliente.Id,
        Nombre = cliente.Nombre,
        Rut = cliente.Rut,
        Email = cliente.Email,
        Telefono = cliente.Telefono,
        Direccion = cliente.Direccion,
        FechaNacimiento = cliente.FechaNacimiento,
        FechaRegistro = cliente.FechaRegistro
    };

    public static PedidoDto ToDto(this Pedido pedido) => new()
    {
        Id = pedido.Id,
        ClienteId = pedido.ClienteId,
        ClienteNombre = pedido.Cliente?.Nombre,
        FechaPedido = pedido.FechaPedido,
        TipoEnvio = pedido.TipoEnvio,
        CostoEnvio = pedido.CostoEnvio,
        MetodoPago = pedido.MetodoPago,
        EstadoEnvio = pedido.EstadoEnvio,
        TotalFinal = pedido.TotalFinal,
        Detalles = pedido.Detalles.Select(d => new DetallePedidoDto
        {
            LibroId = d.LibroId,
            LibroTitulo = d.Libro?.Titulo,
            Cantidad = d.Cantidad,
            PrecioUnitario = d.PrecioUnitario,
            Subtotal = d.Subtotal
        }).ToList()
    };
}
using LibreriaSparrow.Api.DTOs;
using LibreriaSparrow.Api.Models;
using LibreriaSparrow.Api.Repositories;

namespace LibreriaSparrow.Api.Services;

public class PedidoService(
    IPedidoRepository pedidoRepository,
    ILibroRepository libroRepository,
    IClienteRepository clienteRepository) : IPedidoService
{
    public Task<List<Pedido>> GetAllAsync() => pedidoRepository.GetAllAsync();

    public Task<Pedido?> GetByIdAsync(int id) => pedidoRepository.GetByIdAsync(id);

    public async Task<Pedido> CreateAsync(CrearPedidoDto dto)
    {
        if (dto.Items.Count == 0)
            throw new ArgumentException("El pedido debe tener al menos un libro.");

        var cliente = await clienteRepository.GetByIdAsync(dto.ClienteId);
        if (cliente is null)
            throw new ArgumentException("El cliente no existe.");

        var pedido = new Pedido
        {
            ClienteId = dto.ClienteId,
            TipoEnvio = dto.TipoEnvio,
            CostoEnvio = dto.CostoEnvio,
            MetodoPago = dto.MetodoPago,
            EstadoEnvio = "Pendiente"
        };

        decimal totalProductos = 0;

        foreach (var item in dto.Items)
        {
            var libro = await libroRepository.GetByIdAsync(item.LibroId)
                ?? throw new ArgumentException($"El libro con id {item.LibroId} no existe.");

            if (libro.Stock < item.Cantidad)
                throw new ArgumentException($"Stock insuficiente para '{libro.Titulo}'. Disponible: {libro.Stock}.");

            libro.Stock -= item.Cantidad;
            libroRepository.Update(libro);

            var detalle = new DetallePedido
            {
                LibroId = libro.Id,
                Cantidad = item.Cantidad,
                PrecioUnitario = libro.Precio
            };

            pedido.Detalles.Add(detalle);
            totalProductos += detalle.Subtotal;
        }

        pedido.TotalFinal = totalProductos + pedido.CostoEnvio;

        await pedidoRepository.AddAsync(pedido);
        await pedidoRepository.SaveChangesAsync();

        return pedido;
    }
}
using LibreriaSparrow.Api.DTOs;
using LibreriaSparrow.Api.Models;

namespace LibreriaSparrow.Api.Services;

public interface IPedidoService
{
    Task<List<Pedido>> GetAllAsync();
    Task<Pedido?> GetByIdAsync(int id);
    Task<Pedido> CreateAsync(CrearPedidoDto dto);
}
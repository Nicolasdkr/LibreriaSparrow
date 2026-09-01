using LibreriaSparrow.Api.Models;

namespace LibreriaSparrow.Api.Repositories;

public interface IPedidoRepository
{
    Task<List<Pedido>> GetAllAsync();
    Task<Pedido?> GetByIdAsync(int id);
    Task AddAsync(Pedido pedido);
    Task<bool> SaveChangesAsync();
}
using Microsoft.EntityFrameworkCore;
using LibreriaSparrow.Api.Data;
using LibreriaSparrow.Api.Models;

namespace LibreriaSparrow.Api.Repositories;

public class PedidoRepository(LibreriaContext context) : IPedidoRepository
{
    public async Task<List<Pedido>> GetAllAsync() =>
        await context.Pedidos
            .Include(p => p.Cliente)
            .Include(p => p.Detalles).ThenInclude(d => d.Libro)
            .ToListAsync();

    public async Task<Pedido?> GetByIdAsync(int id) =>
        await context.Pedidos
            .Include(p => p.Cliente)
            .Include(p => p.Detalles).ThenInclude(d => d.Libro)
            .FirstOrDefaultAsync(p => p.Id == id);

    public async Task AddAsync(Pedido pedido) =>
        await context.Pedidos.AddAsync(pedido);

    public async Task<bool> SaveChangesAsync() =>
        await context.SaveChangesAsync() > 0;
}
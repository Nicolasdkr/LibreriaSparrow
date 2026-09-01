using Microsoft.EntityFrameworkCore;
using LibreriaSparrow.Api.Data;
using LibreriaSparrow.Api.Models;

namespace LibreriaSparrow.Api.Repositories;

public class ClienteRepository(LibreriaContext context) : IClienteRepository
{
    public async Task<List<Cliente>> GetAllAsync() =>
        await context.Clientes.Include(c => c.Pedidos).ToListAsync();

    public async Task<Cliente?> GetByIdAsync(int id) =>
        await context.Clientes.Include(c => c.Pedidos)
            .FirstOrDefaultAsync(c => c.Id == id);

    public async Task AddAsync(Cliente cliente) =>
        await context.Clientes.AddAsync(cliente);

    public void Update(Cliente cliente) =>
        context.Clientes.Update(cliente);

    public void Delete(Cliente cliente) =>
        context.Clientes.Remove(cliente);

    public async Task<bool> SaveChangesAsync() =>
        await context.SaveChangesAsync() > 0;
}
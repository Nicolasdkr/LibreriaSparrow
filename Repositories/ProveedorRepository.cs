using Microsoft.EntityFrameworkCore;
using LibreriaSparrow.Api.Data;
using LibreriaSparrow.Api.Models;

namespace LibreriaSparrow.Api.Repositories;

public class ProveedorRepository(LibreriaContext context) : IProveedorRepository
{
    public async Task<List<Proveedor>> GetAllAsync() =>
        await context.Proveedores.Include(p => p.Libros).ToListAsync();
    public async Task<Proveedor?> GetByIdAsync(int id) =>
        await context.Proveedores.Include(p => p.Libros)
            .FirstOrDefaultAsync(p => p.Id == id);
    public async Task AddAsync(Proveedor proveedor) =>
        await context.Proveedores.AddAsync(proveedor);
    public void Update(Proveedor proveedor) =>
        context.Proveedores.Update(proveedor);
    public void Delete(Proveedor proveedor) =>
        context.Proveedores.Remove(proveedor);
    public async Task<bool> SaveChangesAsync() =>
        await context.SaveChangesAsync() > 0;
}
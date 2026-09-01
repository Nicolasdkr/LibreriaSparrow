using Microsoft.EntityFrameworkCore;
using LibreriaSparrow.Api.Data;
using LibreriaSparrow.Api.Models;

namespace LibreriaSparrow.Api.Repositories;

public class LibroRepository(LibreriaContext context) : ILibroRepository
{
    public async Task<List<Libro>> GetAllAsync() =>
        await context.Libros.Include(l => l.Proveedor).ToListAsync();

    public async Task<Libro?> GetByIdAsync(int id) =>
        await context.Libros.Include(l => l.Proveedor)
            .FirstOrDefaultAsync(l => l.Id == id);

    public async Task AddAsync(Libro libro) =>
        await context.Libros.AddAsync(libro);

    public void Update(Libro libro) =>
        context.Libros.Update(libro);

    public void Delete(Libro libro) =>
        context.Libros.Remove(libro);

    public async Task<bool> SaveChangesAsync() =>
        await context.SaveChangesAsync() > 0;
}
using LibreriaSparrow.Api.Models;
using LibreriaSparrow.Api.Repositories;

namespace LibreriaSparrow.Api.Services;

public class LibroService(ILibroRepository repository) : ILibroService
{
    public Task<List<Libro>> GetAllAsync() => repository.GetAllAsync();

    public Task<Libro?> GetByIdAsync(int id) => repository.GetByIdAsync(id);

    public async Task<Libro> CreateAsync(Libro libro)
    {
        if (libro.Precio <= 0)
            throw new ArgumentException("El precio debe ser mayor a cero.");

        await repository.AddAsync(libro);
        await repository.SaveChangesAsync();
        return libro;
    }

    public async Task<bool> UpdateAsync(int id, Libro libro)
    {
        var existente = await repository.GetByIdAsync(id);
        if (existente is null) return false;

        existente.Titulo = libro.Titulo;
        existente.Autor = libro.Autor;
        existente.Descripcion = libro.Descripcion;
        existente.Categoria = libro.Categoria;
        existente.Precio = libro.Precio;
        existente.Stock = libro.Stock;
        existente.Estado = libro.Estado;
        existente.ProveedorId = libro.ProveedorId;

        repository.Update(existente);
        return await repository.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existente = await repository.GetByIdAsync(id);
        if (existente is null) return false;

        repository.Delete(existente);
        return await repository.SaveChangesAsync();
    }
}
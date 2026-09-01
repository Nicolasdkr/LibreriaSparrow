using LibreriaSparrow.Api.Models;

namespace LibreriaSparrow.Api.Services;

public interface ILibroService
{
    Task<List<Libro>> GetAllAsync();
    Task<Libro?> GetByIdAsync(int id);
    Task<Libro> CreateAsync(Libro libro);
    Task<bool> UpdateAsync(int id, Libro libro);
    Task<bool> DeleteAsync(int id);
}
using LibreriaSparrow.Api.Models;

namespace LibreriaSparrow.Api.Repositories;

public interface ILibroRepository
{
    Task<List<Libro>> GetAllAsync();
    Task<Libro?> GetByIdAsync(int id);
    Task AddAsync(Libro libro);
    void Update(Libro libro);
    void Delete(Libro libro);
    Task<bool> SaveChangesAsync();
}
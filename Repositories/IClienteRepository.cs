using LibreriaSparrow.Api.Models;

namespace LibreriaSparrow.Api.Repositories;

public interface IClienteRepository
{
    Task<List<Cliente>> GetAllAsync();
    Task<Cliente?> GetByIdAsync(int id);
    Task AddAsync(Cliente cliente);
    void Update(Cliente cliente);
    void Delete(Cliente cliente);
    Task<bool> SaveChangesAsync();
}
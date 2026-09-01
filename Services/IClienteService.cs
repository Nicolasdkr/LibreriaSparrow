using LibreriaSparrow.Api.Models;

namespace LibreriaSparrow.Api.Services;

public interface IClienteService
{
    Task<List<Cliente>> GetAllAsync();
    Task<Cliente?> GetByIdAsync(int id);
    Task<Cliente> CreateAsync(Cliente cliente);
    Task<bool> UpdateAsync(int id, Cliente cliente);
    Task<bool> DeleteAsync(int id);
}
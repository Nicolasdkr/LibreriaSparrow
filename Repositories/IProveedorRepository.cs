using LibreriaSparrow.Api.Models;

namespace LibreriaSparrow.Api.Repositories;

public interface IProveedorRepository
{
    Task<List<Proveedor>> GetAllAsync();
    Task<Proveedor?> GetByIdAsync(int id);
    Task AddAsync(Proveedor proveedor);
    void Update(Proveedor proveedor);
    void Delete(Proveedor proveedor);
    Task<bool> SaveChangesAsync();
}
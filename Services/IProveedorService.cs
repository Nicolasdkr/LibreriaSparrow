using LibreriaSparrow.Api.Models;

namespace LibreriaSparrow.Api.Services;

public interface IProveedorService
{
    Task<List<Proveedor>> GetAllAsync();
    Task<Proveedor?> GetByIdAsync(int id);
    Task<Proveedor> CreateAsync(Proveedor proveedor);
    Task<bool> UpdateAsync(int id, Proveedor proveedor);
    Task<bool> DeleteAsync(int id);
}
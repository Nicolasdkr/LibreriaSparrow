using LibreriaSparrow.Api.Models;
using LibreriaSparrow.Api.Repositories;

namespace LibreriaSparrow.Api.Services;

public class ProveedorService(IProveedorRepository repository) : IProveedorService
{
    public Task<List<Proveedor>> GetAllAsync() => repository.GetAllAsync();

    public Task<Proveedor?> GetByIdAsync(int id) => repository.GetByIdAsync(id);

    public async Task<Proveedor> CreateAsync(Proveedor proveedor)
    {
        if (string.IsNullOrWhiteSpace(proveedor.Nombre))
            throw new ArgumentException("El nombre del proveedor no puede estar vacío.");

        await repository.AddAsync(proveedor);
        await repository.SaveChangesAsync();
        return proveedor;
    }

    public async Task<bool> UpdateAsync(int id, Proveedor proveedor)
    {
        var existente = await repository.GetByIdAsync(id);
        if (existente is null) return false;

        existente.Nombre = proveedor.Nombre;
        existente.Contacto = proveedor.Contacto;
        existente.Telefono = proveedor.Telefono;

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
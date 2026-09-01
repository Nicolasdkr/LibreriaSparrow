using LibreriaSparrow.Api.Models;
using LibreriaSparrow.Api.Repositories;

namespace LibreriaSparrow.Api.Services;


public class ClienteService(IClienteRepository repository) : IClienteService
{
    public Task<List<Cliente>> GetAllAsync() => repository.GetAllAsync();
    public Task<Cliente?> GetByIdAsync(int id) => repository.GetByIdAsync(id);
    public async Task<Cliente> CreateAsync(Cliente cliente)
    {
        if (string.IsNullOrWhiteSpace(cliente.Nombre))
            throw new ArgumentException("El nombre del cliente no puede estar vacío.");

        var clientes = await repository.GetAllAsync();
        if (clientes.Any(c => c.Rut == cliente.Rut))
            throw new ArgumentException("Ya existe un cliente con ese RUT.");

        await repository.AddAsync(cliente);
        await repository.SaveChangesAsync();
        return cliente;
    }
    public async Task<bool> UpdateAsync(int id, Cliente cliente)
    {
        var existente = await repository.GetByIdAsync(id);
        if (existente is null) return false;

        existente.Nombre = cliente.Nombre;
        existente.Rut = cliente.Rut;
        existente.Email = cliente.Email;
        existente.Telefono = cliente.Telefono;
        existente.Direccion = cliente.Direccion;
        existente.FechaNacimiento = cliente.FechaNacimiento;

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
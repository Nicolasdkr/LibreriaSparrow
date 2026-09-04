using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LibreriaSparrow.Api.Models;
using LibreriaSparrow.Api.Services;
using LibreriaSparrow.Api.Mappers;

namespace LibreriaSparrow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController(IClienteService service) : ControllerBase
{
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok((await service.GetAllAsync()).Select(c => c.ToDto()));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var cliente = await service.GetByIdAsync(id);
        return cliente is null ? NotFound() : Ok(cliente.ToDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create(Cliente cliente)
    {
        try
        {
            var creado = await service.CreateAsync(cliente);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado.ToDto());
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Cliente cliente) =>
        await service.UpdateAsync(id, cliente) ? NoContent() : NotFound();

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) =>
        await service.DeleteAsync(id) ? NoContent() : NotFound();
}
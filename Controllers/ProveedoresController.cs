using Microsoft.AspNetCore.Mvc;
using LibreriaSparrow.Api.Models;
using LibreriaSparrow.Api.Services;

namespace LibreriaSparrow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProveedoresController(IProveedorService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var proveedor = await service.GetByIdAsync(id);
        return proveedor is null ? NotFound() : Ok(proveedor);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Proveedor proveedor)
    {
        try
        {
            var creado = await service.CreateAsync(proveedor);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Proveedor proveedor) =>
        await service.UpdateAsync(id, proveedor) ? NoContent() : NotFound();

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) =>
        await service.DeleteAsync(id) ? NoContent() : NotFound();
}
using Microsoft.AspNetCore.Mvc;
using LibreriaSparrow.Api.Models;
using LibreriaSparrow.Api.Services;
using Microsoft.AspNetCore.Authorization;

namespace LibreriaSparrow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LibrosController(ILibroService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var libro = await service.GetByIdAsync(id);
        return libro is null ? NotFound() : Ok(libro);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create(Libro libro)
    {
        try
        {
            var creado = await service.CreateAsync(libro);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Libro libro) =>
        await service.UpdateAsync(id, libro) ? NoContent() : NotFound();

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) =>
        await service.DeleteAsync(id) ? NoContent() : NotFound();
}
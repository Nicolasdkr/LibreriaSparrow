using Microsoft.AspNetCore.Mvc;
using LibreriaSparrow.Api.DTOs;
using LibreriaSparrow.Api.Services;

namespace LibreriaSparrow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidosController(IPedidoService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var pedido = await service.GetByIdAsync(id);
        return pedido is null ? NotFound() : Ok(pedido);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CrearPedidoDto dto)
    {
        try
        {
            var creado = await service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
using APIBankConsult.DTOs;
using AutoMapper;
using BackendAPI.Domain.Entities;
using BackendAPI.Services;
using BackendAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIBankConsult.Controllers;

[ApiController]
[Route("api/movimientos")]
public class MovimientoController : ControllerBase
{
    private readonly IMovimientoService _movimientoService;
    private readonly IMapper _mapper;

    public MovimientoController(IMovimientoService movimientoService, IMapper mapper)
    {
        _movimientoService = movimientoService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetMovimientos()
    {
        var movimientos = await _movimientoService.GetMovimientos();
        return Ok(movimientos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMovimientoById(int id)
    {
        try
        {
            var movimiento = await _movimientoService.GetMovimientoById(id);
            return Ok(movimiento);
        } 
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { mensaje = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> RegistrarMovimiento([FromBody] MovimientoDto movimientoDto)
    {
        try
        {
            var movimiento = _mapper.Map<Movimiento>(movimientoDto);
            
            await _movimientoService.AddMovimiento(movimiento);

            return CreatedAtAction(nameof(GetMovimientoById), new { id = movimiento.MovimientoId }, movimientoDto);

        }
        catch(KeyNotFoundException ex)
        {
            return NotFound(new {mensaje = ex.Message});
        }
        catch(ArgumentException ex)
        {
            return BadRequest(new { mensaje = ex.Message });
        }
    }

}

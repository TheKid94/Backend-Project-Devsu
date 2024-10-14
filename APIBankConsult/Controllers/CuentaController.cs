using APIBankConsult.DTOs;
using AutoMapper;
using BackendAPI.Domain.Entities;
using BackendAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIBankConsult.Controllers;

[ApiController]
[Route("api/cuentas")]
public class CuentaController : ControllerBase
{
    private readonly ICuentaService _cuentaService;
    private readonly IMapper _mapper;

    public CuentaController(ICuentaService cuentaService, IMapper mapper)
    {
        _cuentaService = cuentaService;
        _mapper = mapper;
    }

    [HttpGet()]
    public async Task<IActionResult> GetCuentas()
    {
        var cuentas = await _cuentaService.GetCuentas();

        return Ok(cuentas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCuentaById(int id)
    {
        try
        {
            var persona = await _cuentaService.GetCuentaById(id);            
            return Ok(persona);

        }catch(KeyNotFoundException ex)
        {
            return NotFound(new { mensaje = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateCuenta([FromBody] CuentaDto cuentaDto)
    {
        var cuenta = _mapper.Map<Cuenta>(cuentaDto);

        await _cuentaService.AddCuenta(cuenta);

        return CreatedAtAction(nameof(GetCuentaById), new { id = cuenta.CuentaId }, cuentaDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCliente(int id, [FromBody] CuentaDto cuentaDto)
    {
        try
        {
            var cuentaExist = await _cuentaService.GetCuentaById(id);

            _mapper.Map(cuentaDto, cuentaExist);

            await _cuentaService.UpdateCuenta(cuentaExist);

            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Ocurrió un error al actualizar el cliente: {ex.Message}");
        }
    }
}

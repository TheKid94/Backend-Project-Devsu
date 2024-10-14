using APICustomers.DTOs;
using AutoMapper;
using BackendAPI.Domain.Entities;
using BackendAPI.Services;
using BackendAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APICustomers.Controllers;

[ApiController]
[Route("api/clientes")]
public class ClienteController : ControllerBase
{
    private readonly IClienteService _clienteService;
    private readonly IMapper _mapper;

    public ClienteController(IClienteService clienteService, IMapper mapper)
    {
        _clienteService = clienteService;
        _mapper = mapper;
    }

    [HttpGet()]
    public async Task<IActionResult> GetClientes()
    {
        var clientes = await _clienteService.GetClientes();

        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetClienteById(int id)
    {
        try 
        { 
            var persona = await _clienteService.GetClienteById(id);
            return Ok(persona);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { mensaje = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateCliente([FromBody] ClienteDto clienteDto)
    {
        var cliente = _mapper.Map<Cliente>(clienteDto);

        await _clienteService.AddCliente(cliente);

        return CreatedAtAction(nameof(GetClienteById), new { id = cliente.ClienteId }, clienteDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCliente(int id, [FromBody] ClienteDto clienteDto)
    {
        try
        {
            var clienteExist = await _clienteService.GetClienteById(id);
            _mapper.Map(clienteDto, clienteExist);

            await _clienteService.UpdateCliente(clienteExist);

            return Ok(); 
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { mensaje = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCliente(int id)
    {
        try
        { 
            var cliente = await _clienteService.GetClienteById(id);
            
            await _clienteService.DeleteCliente(cliente);
            
            return Ok(new { mensaje = "Cliente eliminado con éxito." });
        
        }catch(KeyNotFoundException ex)
        {
            return NotFound(new { mensaje = ex.Message });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { mensaje = ex.Message });
        }
    }
}

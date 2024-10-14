using APICustomers.DTOs;
using AutoMapper;
using BackendAPI.Domain.Entities;
using BackendAPI.Services;
using BackendAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APICustomers.Controllers;

[ApiController]
[Route("api/personas")]
public class PersonaController : ControllerBase
{
    private readonly IPersonaService _personaService;
    private readonly IMapper _mapper;

    public PersonaController(IPersonaService personaService, IMapper mapper)
    {
        _personaService = personaService;
        _mapper = mapper;
    }

    [HttpGet()]
    public async Task<IActionResult> GetPersonas()
    {
        var persona = await _personaService.GetPersonas();

        return Ok(persona);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPersonaById(int id)
    {
        try
        {
            var persona = await _personaService.GetPersonaById(id);
            return Ok(persona);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { mensaje = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreatePersona([FromBody] PersonaDto personaDto)
    {
        var persona = _mapper.Map<Persona>(personaDto);

        await _personaService.AddPersona(persona);

        return CreatedAtAction(nameof(GetPersonaById), new { id = persona.PersonaId }, personaDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePersona(int id, [FromBody] PersonaDto personaDto)
    {
        try
        {
            var personaExist = await _personaService.GetPersonaById(id);
            _mapper.Map(personaDto, personaExist);

            await _personaService.UpdatePersona(personaExist);

            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { mensaje = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePersona(int id)
    {
        try
        {
            var persona = await _personaService.GetPersonaById(id);

            await _personaService.DeletePersona(persona);
            return Ok(new { mensaje = "Persona eliminado con éxito." });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { mensaje = ex.Message });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { mensaje = ex.Message });
        }
    }
}

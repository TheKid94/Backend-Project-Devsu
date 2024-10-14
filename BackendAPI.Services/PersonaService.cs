using BackendAPI.Data.Repositories;
using BackendAPI.Data.Repositories.Interfaces;
using BackendAPI.Domain.Entities;
using BackendAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAPI.Services;

public class PersonaService : IPersonaService
{
    private readonly IPersonaRepository _personaRepository;
    private readonly IClienteRepository _clienteRepository;

    public PersonaService(IPersonaRepository personaRepository, IClienteRepository clienteRepository)
    {
        _personaRepository = personaRepository;
        _clienteRepository = clienteRepository;
    }

    public async Task AddPersona(Persona persona)
    {
        await _personaRepository.AddPersona(persona);
    }

    public async Task DeletePersona(Persona persona)
    {
        await ClienteAsociados(persona);
        await _personaRepository.DeletePersona(persona);
    }

    public async Task<Persona> GetPersonaById(int id)
    {
        var persona = await _personaRepository.GetPersonaById(id);
        if (persona is null)
        {
            throw new KeyNotFoundException($"La Persona con ID {id} no fue encontrada.");
        }
        return persona;
    }

    public async Task<List<Persona>> GetPersonas()
    {
        return await _personaRepository.GetPersonas();
    }

    public async Task UpdatePersona(Persona persona)
    {
        await _personaRepository.UpdatePersona(persona);
    }

    private async Task ClienteAsociados(Persona persona)
    {
        var clienteAsociados = await _clienteRepository.GetClientes();
        if(clienteAsociados.Any(x=>x.PersonaId == persona.PersonaId))
        {
            throw new ArgumentException("No se puede eliminar la persona porque está vinculada a una cuenta.");
        }
    }
}

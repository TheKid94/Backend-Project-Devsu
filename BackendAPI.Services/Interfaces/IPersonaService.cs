using BackendAPI.Domain.Entities;

namespace BackendAPI.Services.Interfaces;

public interface IPersonaService
{
    Task<List<Persona>> GetPersonas();
    Task<Persona> GetPersonaById(int id);
    Task AddPersona(Persona persona);
    Task UpdatePersona(Persona persona);
    Task DeletePersona(Persona persona);

}

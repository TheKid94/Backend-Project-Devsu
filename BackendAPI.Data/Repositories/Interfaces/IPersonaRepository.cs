using BackendAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAPI.Data.Repositories.Interfaces;

public interface IPersonaRepository
{
    Task<List<Persona>> GetPersonas();
    Task<Persona?> GetPersonaById(int id);
    Task AddPersona(Persona persona);
    Task UpdatePersona(Persona persona);
    Task DeletePersona(Persona persona);

}

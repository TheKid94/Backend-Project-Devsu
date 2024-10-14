using BackendAPI.Data.Repositories.Interfaces;
using BackendAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAPI.Data.Repositories;

public class PersonaRepository : IPersonaRepository
{
    private readonly AppDbContext _context;
    public PersonaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddPersona(Persona persona)
    {
        _context.Personas.Add(persona);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePersona(Persona persona)
    {
        _context.Personas.Remove(persona);
        await _context.SaveChangesAsync();
    }

    public async Task<Persona?> GetPersonaById(int id)
    {
        return await _context.Personas.Where(x => x.PersonaId == id).FirstOrDefaultAsync();
    }

    public async Task<List<Persona>> GetPersonas()
    {
        return await _context.Personas.ToListAsync();
    }

    public async Task UpdatePersona(Persona persona)
    {
        _context.Personas.Update(persona);
        await _context.SaveChangesAsync();
    }
}

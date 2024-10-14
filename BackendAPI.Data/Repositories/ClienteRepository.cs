using BackendAPI.Data.Repositories.Interfaces;
using BackendAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAPI.Data.Repositories;

public class ClienteRepository:IClienteRepository
{
    private readonly AppDbContext _context;
    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddCliente(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCliente(Cliente cliente)
    {
        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Cliente>> GetClientes()
    {
        return await _context.Clientes.ToListAsync();
    }

    public async Task<Cliente?> GetClienteById(int id)
    {
        return await _context.Clientes.Where(x => x.ClienteId == id).FirstOrDefaultAsync();
    }

    public async Task UpdateCliente(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
        await _context.SaveChangesAsync();
    }
}

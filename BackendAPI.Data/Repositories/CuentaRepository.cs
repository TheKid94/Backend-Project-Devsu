using BackendAPI.Data.Repositories.Interfaces;
using BackendAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAPI.Data.Repositories;

public class CuentaRepository:ICuentaRepository
{
    private readonly AppDbContext _context;
    public CuentaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddCuenta(Cuenta cuenta)
    {
        _context.Cuentas.Add(cuenta);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCuenta(Cuenta cuenta)
    {
        _context.Cuentas.Remove(cuenta);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Cuenta>> GetCuentas()
    {
        return await _context.Cuentas.ToListAsync();
    }

    public async Task<Cuenta?> GetCuentaById(int id)
    {
        return await _context.Cuentas.Where(x => x.CuentaId == id).FirstOrDefaultAsync();
    }

    public async Task UpdateCuenta(Cuenta cuenta)
    {
        _context.Cuentas.Update(cuenta);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Cuenta>> GetCuentasByClienteId(int clienteId)
    {
        return await _context.Cuentas
            .Where(x => x.ClienteId == clienteId)
            .ToListAsync();
    }
}

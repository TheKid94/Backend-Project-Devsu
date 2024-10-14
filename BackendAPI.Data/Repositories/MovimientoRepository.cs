using BackendAPI.Data.Repositories.Interfaces;
using BackendAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAPI.Data.Repositories;

public class MovimientoRepository:IMovimientoRepository
{
    private readonly AppDbContext _context;
    public MovimientoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddMovimiento(Movimiento movimiento)
    {
        _context.Movimientos.Add(movimiento);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteMovimiento(Movimiento movimiento)
    {
        _context.Movimientos.Remove(movimiento);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Movimiento>> GetMovimientos()
    {
        return await _context.Movimientos.ToListAsync();
    }

    public async Task<Movimiento?> GetMovimientoById(int id)
    {
        return await _context.Movimientos.Where(x => x.MovimientoId == id).FirstOrDefaultAsync();
    }

    public async Task<List<Movimiento>> GetMovimientosByCuentaIdAndDateFilters(int cuentaId, DateTime fechaInicio, DateTime fechaFin)
    {
        return await _context.Movimientos
                    .Where(x => x.CuentaId==cuentaId && x.Fecha>= fechaInicio && x.Fecha <= fechaFin)
                    .ToListAsync();
    }
}

using BackendAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAPI.Services.Interfaces;

public interface IMovimientoService
{
    Task<Movimiento?> GetMovimientoById(int id);
    Task<List<Movimiento>> GetMovimientos();
    Task AddMovimiento(Movimiento movimiento);
    Task DeleteMovimiento(Movimiento movimiento);
}

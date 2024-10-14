using BackendAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAPI.Data.Repositories.Interfaces
{
    public interface IMovimientoRepository
    {
        Task<List<Movimiento>> GetMovimientos();
        Task<List<Movimiento>> GetMovimientosByCuentaIdAndDateFilters(int cuentaId, DateTime fechaInicio, DateTime fechaFin);
        Task<Movimiento?> GetMovimientoById(int id);
        Task AddMovimiento(Movimiento movimiento);
        Task DeleteMovimiento(Movimiento movimiento);
    }
}

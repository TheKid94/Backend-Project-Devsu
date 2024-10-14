using BackendAPI.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAPI.Services.Interfaces
{
    public interface IReporteService
    {
        Task<ReporteEstadoCuentaDto> GetReporteEstadoCuenta(int clienteId, DateTime fechaInicio, DateTime fechaFin);
    }
}

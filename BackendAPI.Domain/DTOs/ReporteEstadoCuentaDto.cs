using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAPI.Domain.DTOs
{
    public class ReporteEstadoCuentaDto
    {
        public string? Cliente { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public List<CuentaDto> Cuentas { get; set; }
    }

    public class CuentaDto
    {
        public string? NumeroCuenta { get; set; }
        public decimal SaldoDisponible { get; set; }
        public decimal SaldoInicial { get; set; }
        public List<MovimientoDto> Movimientos { get; set; }
    }

    public class MovimientoDto
    {
        public DateTime Fecha { get; set; }
        public string? Tipo { get; set; }
        public decimal Movimiento { get; set; }
    }
}

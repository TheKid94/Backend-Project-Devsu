using BackendAPI.Data.Repositories.Interfaces;
using BackendAPI.Domain.DTOs;
using BackendAPI.Services.Interfaces;

namespace BackendAPI.Services;

public class ReporteService : IReporteService
{
    private readonly ICuentaRepository _cuentaRepository;
    private readonly IMovimientoRepository _movimientoRepository;
    private readonly IClienteRepository _clienteRepository;
    private readonly IPersonaRepository _personaRepository;

    public ReporteService(ICuentaRepository cuentaRepository, IMovimientoRepository movimientoRepository, IClienteRepository clienteRepository, IPersonaRepository personaRepository)
    {
        _cuentaRepository = cuentaRepository;
        _movimientoRepository = movimientoRepository;
        _clienteRepository = clienteRepository;
        _personaRepository = personaRepository;
    }

    public async Task<ReporteEstadoCuentaDto> GetReporteEstadoCuenta(int clienteId, DateTime fechaInicio, DateTime fechaFin)
    {
        var cliente = await _clienteRepository.GetClienteById(clienteId);
        if (cliente is null)
        {
            throw new KeyNotFoundException($"El Cliente con ID {clienteId} no fue encontrada.");
        }
        var persona = await _personaRepository.GetPersonaById(cliente.PersonaId);
        var cuentas = await _cuentaRepository.GetCuentasByClienteId(clienteId);
        if (!cuentas.Any())
        {
            throw new KeyNotFoundException("No hay cuentas para el cliente especificado");
        }
        var reporte = new ReporteEstadoCuentaDto()
        {
            Cliente = $"{persona.Nombre} {persona.Apellido}",
            FechaInicio = fechaInicio,
            FechaFin = fechaFin,
            Cuentas = new List<CuentaDto>()
        };

        foreach (var cuenta in cuentas)
        {
            var movimientos = await _movimientoRepository.GetMovimientosByCuentaIdAndDateFilters(cuenta.CuentaId, fechaInicio, fechaFin);

            var cuentaDto = new CuentaDto()
            {
                NumeroCuenta = cuenta.Numero,
                SaldoDisponible = cuenta.Saldo,
                SaldoInicial = cuenta.SaldoInicial,
                Movimientos = movimientos.Select(x => new MovimientoDto
                {
                    Fecha = x.Fecha,
                    Movimiento = x.Valor,
                    Tipo = x.Tipo
                }).ToList()
            };

            reporte.Cuentas.Add(cuentaDto);
        }

        return reporte;
    }
}

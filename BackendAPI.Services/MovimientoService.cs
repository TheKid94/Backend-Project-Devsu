using BackendAPI.Data.Repositories.Interfaces;
using BackendAPI.Data.Repositories;
using BackendAPI.Domain.Entities;
using BackendAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAPI.Services;

public class MovimientoService : IMovimientoService
{
    private readonly IMovimientoRepository _movimientoRepository;
    private readonly ICuentaRepository _cuentaRepository;

    public MovimientoService(IMovimientoRepository movimientoRepository, ICuentaRepository cuentaRepository)
    {
        _movimientoRepository = movimientoRepository;
        _cuentaRepository = cuentaRepository;
    }

    public async Task AddMovimiento(Movimiento movimiento)
    {

        await CheckCuentaSaldoDisponible(movimiento.CuentaId, movimiento.Valor);
        decimal saldoActualizado = await CuentaUpdateSaldo(movimiento.CuentaId, movimiento.Valor);
        movimiento.Saldo = saldoActualizado;
        await _movimientoRepository.AddMovimiento(movimiento);
    }

    public async Task DeleteMovimiento(Movimiento movimiento)
    {
        await _movimientoRepository.DeleteMovimiento(movimiento);
    }

    public async Task<List<Movimiento>> GetMovimientos()
    {
        return await _movimientoRepository.GetMovimientos();
    }

    public async Task<Movimiento?> GetMovimientoById(int id)
    {
        var movimiento = await _movimientoRepository.GetMovimientoById(id);
        if (movimiento is null)
        {
            throw new KeyNotFoundException($"El Movimiento con ID {id} no fue encontrada.");
        }
        return movimiento;
    }

    private async Task CheckCuentaSaldoDisponible(int cuentaId, decimal valor)
    {
        var cuenta = await _cuentaRepository.GetCuentaById(cuentaId);
        if(cuenta is null)
        {
            throw new KeyNotFoundException($"La cuenta con ID {cuentaId} no fue encontrada.");
        }
        if(valor<0 && (cuenta.Saldo+valor)<=0)
        {
            throw new ArgumentException($"La cuenta con numero {cuenta.Numero} no tiene el Saldo Disponible para hacer movimiento");
        }
    }

    private async Task<decimal> CuentaUpdateSaldo(int cuentaId, decimal valor)
    {
        var cuenta = await _cuentaRepository.GetCuentaById(cuentaId);

        cuenta.Saldo = cuenta.Saldo + valor;
        
        await _cuentaRepository.UpdateCuenta(cuenta);
        
        return cuenta.Saldo;
    }
}

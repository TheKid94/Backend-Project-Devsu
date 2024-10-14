using BackendAPI.Data.Repositories;
using BackendAPI.Data.Repositories.Interfaces;
using BackendAPI.Domain.Entities;
using BackendAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAPI.Services;

public class CuentaService : ICuentaService
{
    private readonly ICuentaRepository _cuentaRepository;
    public CuentaService(ICuentaRepository cuentaRepository)
    {
        _cuentaRepository = cuentaRepository;
    }

    public async Task AddCuenta(Cuenta cuenta)
    {
        await _cuentaRepository.AddCuenta(cuenta);
    }

    public async Task DeleteCuenta(Cuenta cuenta)
    {
        await _cuentaRepository.DeleteCuenta(cuenta);
    }

    public async Task<Cuenta?> GetCuentaById(int id)
    {
        var cuenta = await _cuentaRepository.GetCuentaById(id);
        if (cuenta is null)
        {
            throw new KeyNotFoundException($"La Cuenta con ID {id} no fue encontrada.");
        }
        return cuenta;
    }

    public async Task<List<Cuenta>> GetCuentas()
    {
        return await _cuentaRepository.GetCuentas();
    }

    public async Task UpdateCuenta(Cuenta cuenta)
    {
        await _cuentaRepository.UpdateCuenta(cuenta);
    }
}

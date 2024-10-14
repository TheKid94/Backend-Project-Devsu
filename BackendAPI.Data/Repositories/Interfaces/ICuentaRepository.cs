using BackendAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAPI.Data.Repositories.Interfaces;

public interface ICuentaRepository
{
    Task<List<Cuenta>> GetCuentas();
    Task<Cuenta?> GetCuentaById(int id);
    Task<List<Cuenta>> GetCuentasByClienteId(int clienteId);
    Task AddCuenta(Cuenta cuenta);
    Task UpdateCuenta(Cuenta cuenta);
    Task DeleteCuenta(Cuenta cuenta);
}

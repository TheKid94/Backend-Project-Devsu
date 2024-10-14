using BackendAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAPI.Data.Repositories.Interfaces;

public interface IClienteRepository
{
    Task<List<Cliente>> GetClientes();
    Task<Cliente?> GetClienteById(int id);
    Task AddCliente(Cliente cliente);
    Task UpdateCliente(Cliente cliente);
    Task DeleteCliente(Cliente cliente);
}

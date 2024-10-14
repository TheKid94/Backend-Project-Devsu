using BackendAPI.Data.Repositories.Interfaces;
using BackendAPI.Domain.Entities;
using BackendAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAPI.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _clienteRepository;
    private readonly ICuentaRepository _cuentaRepository;

    public ClienteService(IClienteRepository clienteRepository, ICuentaRepository cuentaRepository)
    {
        _clienteRepository = clienteRepository;
        _cuentaRepository = cuentaRepository;
    }

    public async Task AddCliente(Cliente cliente)
    {
        await _clienteRepository.AddCliente(cliente);
    }

    public async Task DeleteCliente(Cliente cliente)
    {
        await CuentaAsociados(cliente);
        await _clienteRepository.DeleteCliente(cliente);
    }

    public async Task<List<Cliente>> GetClientes()
    {
        return await _clienteRepository.GetClientes();
    }

    public async Task<Cliente> GetClienteById(int id)
    {
        var cliente = await _clienteRepository.GetClienteById(id);
        if (cliente is null)
        {
            throw new KeyNotFoundException($"El Cliente con ID {id} no fue encontrada.");
        }
        return cliente;
    }

    public async Task UpdateCliente(Cliente cliente)
    {
        await _clienteRepository.UpdateCliente(cliente);
    }

    private async Task CuentaAsociados(Cliente cliente)
    {
        var clienteAsociados = await _cuentaRepository.GetCuentas();
        if (clienteAsociados.Any(x => x.ClienteId == cliente.ClienteId))
        {
            throw new ArgumentException("No se puede eliminar al cliente porque está vinculado a una cuenta.");
        }
    }
}

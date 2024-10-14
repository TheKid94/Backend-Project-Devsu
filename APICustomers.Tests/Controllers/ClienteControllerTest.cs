using BackendAPI.Data;
using BackendAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace APICustomers.Tests.Controllers;

public class ClienteControllerTest
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public ClienteControllerTest(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }

    [Fact]
    public async Task GetClienteById_ClienteExiste_RetornarOk()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDb")
            .Options;

        using (var context = new AppDbContext(options))
        {
            var cliente = new Cliente { ClienteId = 1, PersonaId = 123, Estado = true };
            context.Clientes.Add(cliente);
            await context.SaveChangesAsync();
        }

        // Act
        var response = await _client.GetAsync("/api/clientes/1");

        // Assert
        response.EnsureSuccessStatusCode();
        var clienteResponse = await response.Content.ReadFromJsonAsync<Cliente>();

        Assert.NotNull(clienteResponse);
        Assert.Equal(1, clienteResponse.ClienteId);
        Assert.Equal(123, clienteResponse.PersonaId);
    }

    [Fact]
    public async Task GetClienteById_ClienteNoExiste_RetornarNotFound()
    {
        // Act
        var response = await _client.GetAsync("/api/clientes/999");

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
    }
}

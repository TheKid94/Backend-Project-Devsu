using BackendAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Data;

public class AppDbContext : DbContext
{
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Cuenta> Cuentas { get; set; }
    public DbSet<Movimiento> Movimientos { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}

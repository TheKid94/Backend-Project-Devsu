namespace BackendAPI.Domain.Entities;

public class Cuenta
{
    public int CuentaId { get; set; }
    public int ClienteId { get; set; }
    public string? Numero { get; set; }
    public string? Tipo { get; set; }
    public decimal SaldoInicial { get; set; }
    public decimal Saldo { get; set; }
    public bool Estado { get; set; }
}

namespace BackendAPI.Domain.Entities;

public class Movimiento
{
    public int MovimientoId { get; set; }
    public int CuentaId { get; set; }
    public DateTime Fecha { get; set; }
    public string? Tipo { get; set; }
    public decimal Valor { get; set; }
    public decimal Saldo { get; set; }
}

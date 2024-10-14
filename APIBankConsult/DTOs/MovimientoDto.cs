namespace APIBankConsult.DTOs
{
    public class MovimientoDto
    {
        public int CuentaId { get; set; }
        public DateTime Fecha { get; set; }
        public string? Tipo { get; set; }
        public decimal Valor { get; set; }
    }
}

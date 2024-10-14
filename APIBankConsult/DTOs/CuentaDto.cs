namespace APIBankConsult.DTOs
{
    public class CuentaDto
    {
        public int ClienteId { get; set; }
        public string? Numero { get; set; }
        public string? Tipo { get; set; }
        public decimal SaldoInicial { get; set; }
        public decimal Saldo { get; set; }
        public bool Estado { get; set; }
    }
}

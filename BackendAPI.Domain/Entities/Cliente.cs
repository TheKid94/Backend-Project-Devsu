namespace BackendAPI.Domain.Entities;

public class Cliente
{
    public int ClienteId { get; set; }
    public int PersonaId { get; set; }
    public string? Password { get; set; }
    public bool Estado { get; set; }
    public bool CambiarEstado(bool nuevoEstado)
    {
        if (nuevoEstado == false && !Estado)
        {
            throw new InvalidOperationException("El estado ya es inactivo.");
        }

        Estado = nuevoEstado;
        return true;
    }
}

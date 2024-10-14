﻿namespace BackendAPI.Domain.Entities;

public class Persona
{
    public int PersonaId { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Genero { get; set; }

    public int Edad { get; set; }

    public int Identificacion { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }
}

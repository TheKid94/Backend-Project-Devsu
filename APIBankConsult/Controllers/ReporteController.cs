using BackendAPI.Domain.Entities;
using BackendAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIBankConsult.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReporteController : ControllerBase
{
    private readonly IReporteService _reporteService;

    public ReporteController(IReporteService reporteService)
    {
        _reporteService = reporteService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerReporte([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFin, int clienteId)
    {
        try
        {
            if (fechaInicio > fechaFin)
            {
                return BadRequest("La fecha de inicio no puede ser mayor que la fecha de fin.");
            }
            
            var reporte = await _reporteService.GetReporteEstadoCuenta(clienteId, fechaInicio, fechaFin);
            
            return Ok(reporte);

        }
        catch (KeyNotFoundException ex) {
            return NotFound(new { mensaje = ex.Message });
        }
    }
}

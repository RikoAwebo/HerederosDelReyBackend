using HerederosDelReyBackend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HerederosDelReyBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly IReporteService _reporteService;

        public ReporteController(IReporteService reporteService)
        {
            _reporteService = reporteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetReporte([FromQuery] DateTime fechaInicial, [FromQuery] DateTime fechaFinal)
        {
            if (fechaInicial > fechaFinal)
            {
                return BadRequest("La fecha inicial no puede ser mayor que la fecha final.");
            }

            var reporte = await _reporteService.GetReport(fechaInicial, fechaFinal);

            return Ok(reporte);
        }
    }
}
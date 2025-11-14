using Microsoft.AspNetCore.Mvc;
using TP_ProgramaciónII_PIPORAMA.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TP_ProgramaciónII_PIPORAMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;
        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        //1.1
        [HttpGet("EntradasRecaudacionXDia")]
        public async Task<IActionResult> GetEntradasRecaudacionXDia(DateTime? fechaInicio, DateTime? fechaFin)
        {
            try
            {
                var result = await _dashboardService.GetEntradasRecaudaciónXDia(fechaInicio, fechaFin);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        //1.2
        [HttpGet("RecaudacionTotalXPelicula")]
        public async Task<IActionResult> GetRecaudacionTotalXPelicula(DateTime? fechaInicio, DateTime? fechaFin, int? recaudacion)
        {
            try
            {
                var result = await _dashboardService.GetRecaudaciónTotalXPelícula(fechaInicio, fechaFin, recaudacion);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        //1.3
        [HttpGet("PromedioEntradasVendidasXSala")]
        public async Task<IActionResult> GetPromedioEntradasVendidasXSala(DateTime? fechaInicio, DateTime? fechaFin)
        {
            try
            {
                var result = await _dashboardService.GetPromedioEntradasVendidasXSala(fechaInicio, fechaFin);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        //3.1
        [HttpGet("CantidadFuncionesPorFranjaHoraria")]
        public async Task<IActionResult> GetCantidadFuncionesPorFranjaHoraria()
        {
            try
            {
                var result = await _dashboardService.GetCantidadFuncionesPorFranjaHoraria();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        //3.2
        [HttpGet("ProximasFunciones")]
        public async Task<IActionResult> GetProximasFunciones()
        {
            try
            {
                var result = await _dashboardService.GetPróximasFunciones();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        //4.1
        [HttpGet("ClientesFrecuentes")]
        public async Task<IActionResult> GetClientesFrecuentes(DateTime? fechaInicio, DateTime? fechaFin, int? compra)
        {
            try
            {
                var result = await _dashboardService.GetClientesFrecuentes(fechaInicio, fechaFin, compra);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        //5.1
        [HttpGet("ProductosMasVendidos")]
        public async Task<IActionResult> GetProductosMasVendidos(DateTime? fechaInicio, DateTime? fechaFin)
        {
            try
            {
                var result = await _dashboardService.GetProductosMásVendidos(fechaInicio, fechaFin);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        //6.1
        [HttpGet("TotalEntradasVendidas")]
        public async Task<IActionResult> GetTotalEntradasVendidas()
        {
            try
            {
                var result = await _dashboardService.GetTotalEntradasVendidas();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        //6.2
        [HttpGet("RecaudacionTotal")]
        public async Task<IActionResult> GetRecaudacionTotal()
        {
            try
            {
                var result = await _dashboardService.GetRecaudacionTotal();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        //6.3
        [HttpGet("PeliculasEnCartelera")]
        public async Task<IActionResult> GetPeliculasEnCartelera()
        {
            try
            {
                var result = await _dashboardService.GetPeliculasEnCartelera();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        //6.4
        [HttpGet("TotalClientesRegistrados")]
        public async Task<IActionResult> GetTotalClientesRegistrados()
        {
            try
            {
                var result = await _dashboardService.GetTotalClientesRegistrados();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

    }
}

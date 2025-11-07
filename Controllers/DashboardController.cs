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
        public async Task<IActionResult> GetEntradasRecaudacionXDia()
        {
            try
            {
                var result = await _dashboardService.GetEntradasRecaudaciónXDia();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        //1.2
        [HttpGet("RecaudacionTotalXPelicula")]
        public async Task<IActionResult> GetRecaudacionTotalXPelicula()
        {
            try
            {
                var result = await _dashboardService.GetRecaudaciónTotalXPelícula();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        //1.3
        [HttpGet("PromedioEntradasVendidasXSala")]
        public async Task<IActionResult> GetPromedioEntradasVendidasXSala()
        {
            try
            {
                var result = await _dashboardService.GetPromedioEntradasVendidasXSala();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        //2.1
        [HttpGet("PeliculasMasVistas")]
        public async Task<IActionResult> GetPeliculasMasVistas()
        {
            try
            {
                var result = await _dashboardService.GetPelículasMásVistas();
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
        public async Task<IActionResult> GetClientesFrecuentes()
        {
            try
            {
                var result = await _dashboardService.GetClientesFrecuentes();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        //5.1
        [HttpGet("ProductosMasVendidos")]
        public async Task<IActionResult> GetProductosMasVendidos()
        {
            try
            {
                var result = await _dashboardService.GetProductosMásVendidos();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        //5.2
        [HttpGet("RecaudacionTotalCombos")]
        public async Task<IActionResult> GetRecaudacionTotalCombos()
        {
            try
            {
                var result = await _dashboardService.GetRecaudacionTotalCombos();
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

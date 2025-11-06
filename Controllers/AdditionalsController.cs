using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_ProgramaciónII_PIPORAMA.Services.Interfaces;

namespace TP_ProgramaciónII_PIPORAMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditionalsController : ControllerBase
    {
        private readonly IAdditionalService _additionalService;
        public AdditionalsController(IAdditionalService additionalService)
        {
            _additionalService = additionalService;
        }
        [HttpGet("barrios")]
        public async Task<IActionResult> GetAllBarrios()
        {
            try
            {
                var barrios = await _additionalService.GetAllBarrios();
                return Ok(barrios);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("tipos-contacto")]
        public async Task<IActionResult> GetAllTiposContacto()
        {
            try
            {
                var tiposContacto = await _additionalService.GetAllTipoContactos();
                return Ok(tiposContacto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("tipos-cliente")]
        public async Task<IActionResult> GetAllTiposCliente()
        {
            try
            {
                var tiposCliente = await _additionalService.GetAllTipoClientes();
                return Ok(tiposCliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        [HttpGet("promociones")]
        public async Task<IActionResult> GetAllPromociones()
        {
            try
            {
                var promociones = await _additionalService.GetAllPromociones();
                return Ok(promociones);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        [HttpGet("salas-butacas")]
        public async Task<IActionResult> GetAllSalasButacas()
        {
            try
            {
                var salasButacas = await _additionalService.GetAllSalasButacas();
                return Ok(salasButacas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        [HttpGet("peliculas")]
        public async Task<IActionResult> GetAllPeliculas()
        {
            try
            {
                var peliculas = await _additionalService.GetAllPeliculas();
                return Ok(peliculas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        [HttpGet("funciones")]
        public async Task<IActionResult> GetAllFunciones()
        {
            try
            {
                var funciones = await _additionalService.GetAllFunciones();
                return Ok(funciones);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        [HttpGet("medios-pago")]
        public async Task<IActionResult> GetAllMediosPago()
        {
            try
            {
                var mediosPago = await _additionalService.GetAllMediosPago();
                return Ok(mediosPago);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        [HttpGet("estados-compra")]
        public async Task<IActionResult> GetAllEstadosCompra()
        {
            try
            {
                var estadosCompra = await _additionalService.GetAllEstadosCompra();
                return Ok(estadosCompra);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        [HttpGet("formas-compra")]
        public async Task<IActionResult> GetAllFormasCompra()
        {
            try
            {
                var formasCompra = await _additionalService.GetAllFormasCompra();
                return Ok(formasCompra);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}

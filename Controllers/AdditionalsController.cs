using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP_ProgramaciónII_PIPORAMA.Data.DTOs.DetailInvoice;
using TP_ProgramaciónII_PIPORAMA.Data.Models;
using TP_ProgramaciónII_PIPORAMA.Services.Interfaces;

namespace TP_ProgramaciónII_PIPORAMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditionalsController : ControllerBase
    {
        private readonly IAdditionalService _additionalService;
        private readonly PIPORAMAContext _context;
        public AdditionalsController(IAdditionalService additionalService, PIPORAMAContext context)
        {
            _additionalService = additionalService;
            _context = context;
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

        [HttpGet("salas")]
        public async Task<IActionResult> GetAllSalas()
        {
            try
            {
                var salas = await _additionalService.GetAllSalas();
                return Ok(salas);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        [HttpGet("empleados-roles")]
        public async Task<IActionResult> GetAllEmpleadosRoles()
        {
            try
            {
                var empleadosRoles = await _additionalService.GetAllEmpleadosRoles();
                return Ok(empleadosRoles);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("consumibles")]
        public async Task<IActionResult> GetAllConsumibles()
        {
            try
            {
                var consumibles = await _additionalService.GetAllConsumibles();
                return Ok(consumibles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        [HttpGet("combos")]
        public async Task<IActionResult> GetAllCombos()
        {
            try
            {
                var combos = await _additionalService.GetAllCombos();
                return Ok(combos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
        [HttpGet("Asientos/disponibles/{idFuncion}")]
        public async Task<ActionResult<IEnumerable<AsientoDTO>>> GetAsientosDisponibles(int idFuncion)
        {
            try
            {
                var funcion = await _context.Funciones
                                        .FirstOrDefaultAsync(f => f.IdFuncion == idFuncion);

                if (funcion == null)
                {
                    return NotFound("Función no encontrada.");
                }
                var idsButacasDeLaSala = await _context.SalaButacas
                                                    .Where(sb => sb.IdSala == funcion.IdSala)
                                                    .Select(sb => sb.IdButaca)
                                                    .ToListAsync();

                var idsButacasOcupadas = await _context.Entradas
                                                   .Where(e => e.IdFuncion == idFuncion)
                                                   .Select(e => e.IdButaca)
                                                   .ToListAsync();

                var idsButacasDisponibles = idsButacasDeLaSala.Except(idsButacasOcupadas);

                var asientos = await _context.Butacas
                                    .Where(b => idsButacasDisponibles.Contains(b.IdButaca))
                                    .Select(b => new AsientoDTO
                                    {
                                        IdAsiento = b.IdButaca,
                                        SeatRow = b.FilaButaca, 
                                        SeatNumber = b.NumButaca  
                                    })
                                    .ToListAsync();

                return Ok(asientos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error al buscar asientos: " + ex.Message);
            }
        }


    }
}

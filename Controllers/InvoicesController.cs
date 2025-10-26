using Microsoft.AspNetCore.Mvc;
using TP_ProgramaciónII_PIPORAMA.Data.DTOs;
using TP_ProgramaciónII_PIPORAMA.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TP_ProgramaciónII_PIPORAMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _service;
        public InvoicesController(IInvoiceService service)
        {
            _service = service;
        }

        // GET: api/<InvoiceController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var invoices = await _service.GetAllInvoices();
                return Ok(invoices);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener las facturas: " + ex.Message);
            }
        }

        // GET api/<InvoiceController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var invoice = await _service.GetInvoiceById(id);
                if (invoice == null)
                {
                    return NotFound("Factura no encontrada");
                }
                return Ok(invoice);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener la factura: " + ex.Message);
            }
        }

        // POST api/<InvoiceController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InvoiceDTO invoice)
        {
            try
            {
                await _service.AddInvoice(invoice);
                return CreatedAtAction(nameof(Get), new { id = invoice.InvoiceId }, invoice);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al agregar la factura: " + ex.Message);
            }
        }

        // DELETE api/<InvoiceController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _service.DeleteInvoice(id);
                if (!result)
                {
                    return NotFound();
                }
                return Ok("Factura anulada con exito.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}

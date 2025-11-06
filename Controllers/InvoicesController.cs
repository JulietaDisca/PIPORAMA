using Microsoft.AspNetCore.Mvc;
using TP_ProgramaciónII_PIPORAMA.Data.DTOs;
using TP_ProgramaciónII_PIPORAMA.Services.Interfaces;

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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InvoiceDTO invoice)
        {
            try
            {
                if (!IsValidForCreate(invoice, out var error))
                {
                    throw new ArgumentException(error);
                }
                var result = await _service.AddInvoice(invoice);
                if (result)
                {
                    return CreatedAtAction(nameof(Get), new { id = invoice.InvoiceId }, invoice);
                }
                return BadRequest("No se pudo crear la factura.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al agregar la factura: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (!IsValidForDelete(id, out var error))
                {
                    throw new ArgumentException(error);
                }
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

        private bool IsValidForCreate(InvoiceDTO invoice, out string error)
        {
            if (invoice == null)
            {
                error = "InvoiceDTO es nulo.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(invoice.DniClient))
            {
                error = "DNI del cliente es requerido.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(invoice.DniEmployee))
            {
                error = "DNI del empleado es requerido.";
                return false;
            }
            if (invoice.InvoiceDate == null)
            {
                error = "Fecha de la factura es requerida.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(invoice.PaymentMethod))
            {
                error = "Medio de pago es requerido.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(invoice.PurchaseStatus))
            {
                error = "Estado de compra es requerido.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(invoice.PurchaseForm))
            {
                error = "Forma de compra es requerida.";
                return false;
            }
            if (invoice.DetailInvoices == null || invoice.DetailInvoices.Count == 0)
            {
                error = "Detalle de la factura es requerido.";
                return false;
            }
            foreach (var df in invoice.DetailInvoices)
            {
                if (df == null)
                {
                    error = "Detalle inválido.";
                    return false;
                }
                if (df.Price == null)
                {
                    error = "Precio del detalle es requerido.";
                    return false;
                }
                if (string.IsNullOrWhiteSpace(df.Consumable) && string.IsNullOrWhiteSpace(df.Combo) && df.Ticket == null && df.Promotion == null)
                {
                    error = "Cada detalle debe contener consumible, combo, ticket o promoción.";
                    return false;
                }
                if (df.Ticket != null)
                {
                    if (df.Ticket.Seat == null || string.IsNullOrWhiteSpace(df.Ticket.Seat.SeatRow) || df.Ticket.Seat.SeatNumber == null)
                    {
                        error = "Butaca del ticket incompleta.";
                        return false;
                    }
                    if (df.Ticket.Function == null || invoice == null || df.Ticket.Function.FunctionDate == null || string.IsNullOrWhiteSpace(df.Ticket.Function.Film) || string.IsNullOrWhiteSpace(df.Ticket.Function.Room))
                    {
                        error = "Función del ticket incompleta.";
                        return false;
                    }
                }
                if (df.Promotion != null && string.IsNullOrWhiteSpace(df.Promotion.Description))
                {
                    error = "Promoción inválida.";
                    return false;
                }
            }
            error = string.Empty;
            return true;
        }

        private bool IsValidForUpdate(InvoiceDTO invoice, out string error)
        {
            if (invoice == null)
            {
                error = "InvoiceDTO es nulo.";
                return false;
            }
            if (invoice.InvoiceId <= 0)
            {
                error = "InvoiceId inválido.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(invoice.DniClient))
            {
                error = "DNI del cliente es requerido.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(invoice.DniEmployee))
            {
                error = "DNI del empleado es requerido.";
                return false;
            }
            if (invoice.InvoiceDate == null)
            {
                error = "Fecha de la factura es requerida.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(invoice.PaymentMethod))
            {
                error = "Medio de pago es requerido.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(invoice.PurchaseStatus))
            {
                error = "Estado de compra es requerido.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(invoice.PurchaseForm))
            {
                error = "Forma de compra es requerida.";
                return false;
            }
            if (invoice.DetailInvoices == null || invoice.DetailInvoices.Count == 0)
            {
                error = "Detalle de la factura es requerido.";
                return false;
            }
            error = string.Empty;
            return true;
        }

        private bool IsValidForDelete(int id, out string error)
        {
            if (id <= 0)
            {
                error = "Id inválido.";
                return false;
            }
            error = string.Empty;
            return true;
        }
    }
}

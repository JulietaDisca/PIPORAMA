using Microsoft.AspNetCore.Mvc;
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
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
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
                    return NotFound();
                }
                return Ok(invoice);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // POST api/<InvoiceController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<InvoiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InvoiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

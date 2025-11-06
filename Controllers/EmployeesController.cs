using Microsoft.AspNetCore.Mvc;
using TP_ProgramaciónII_PIPORAMA.Data.DTOs.Invoice;
using TP_ProgramaciónII_PIPORAMA.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TP_ProgramaciónII_PIPORAMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;
        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var employees = await _service.GetAllEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var employee = await _service.GetEmployeeById(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeDTO employee)
        {
            try
            {
                await _service.AddEmployee(employee);
                return Ok("Empleado creado correctamente");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeDTO employee)
        {
            try
            {
                await _service.UpdateEmployee(employee);
                return Ok("Empleado actualizado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var employee = await _service.GetEmployeeById(id);
                if (employee == null)
                {
                    return NotFound();
                }
                await _service.DeleteEmployee(id);
                return Ok("Empleado eliminado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
<<<<<<< Updated upstream
=======

        [HttpPut("/activate/{id}")]
        public async Task<IActionResult> ActivateEmployee(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException("Id inválido.");
                }
                var result = await _service.ActivateEmployee(id);
                if (!result)
                {
                    return NotFound("Empleado no encontrado.");
                }
                return Ok("Empleado activado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        private bool IsValidForCreate(EmployeeDTO employee, out string error)
        {
            if (employee == null)
            {
                error = "EmployeeDTO es nulo.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(employee.DniEmpleado))
            {
                error = "DNI del empleado es requerido.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(employee.NomEmpleado))
            {
                error = "Nombre del empleado es requerido.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(employee.ApeEmpleado))
            {
                error = "Apellido del empleado es requerido.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(employee.Usuario))
            {
                error = "Usuario es requerido.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(employee.Contrasenia))
            {
                error = "Contraseña es requerida.";
                return false;
            }
            error = string.Empty;
            return true;
        }

        private bool IsValidForUpdate(EmployeeDTO employee, out string error)
        {
            if (employee == null)
            {
                error = "EmployeeDTO es nulo.";
                return false;
            }
            if (employee.IdEmpleado <= 0)
            {
                error = "IdEmpleado inválido.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(employee.DniEmpleado))
            {
                error = "DNI del empleado es requerido.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(employee.NomEmpleado))
            {
                error = "Nombre del empleado es requerido.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(employee.ApeEmpleado))
            {
                error = "Apellido del empleado es requerido.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(employee.Usuario))
            {
                error = "Usuario es requerido.";
                return false;
            }
            if (employee.IdBarrio <= 0)
            {
                error = "IdBarrio inválido.";
                return false;
            }
            if (employee.Barrio == null || employee.Barrio.IdBarrio <= 0)
            {
                error = "Barrio inválido.";
                return false;
            }
            if (employee.IdContacto <= 0)
            {
                error = "IdContacto inválido.";
                return false;
            }
            if (employee.Contacto == null || employee.Contacto.IdContacto <= 0)
            {
                error = "Contacto inválido.";
                return false;
            }
            error = string.Empty;
            return true;
        }

        private bool IsValidForDelete(string dni, out string error)
        {
            if (string.IsNullOrWhiteSpace(dni))
            {
                error = "DNI inválido.";
                return false;
            }
            error = string.Empty;
            return true;
        }
>>>>>>> Stashed changes
    }
}

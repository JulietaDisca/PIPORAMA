using Microsoft.AspNetCore.Mvc;
using TP_ProgramaciónII_PIPORAMA.Data.DTOs.Invoice;
using TP_ProgramaciónII_PIPORAMA.Services.Interfaces;

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

        [HttpGet("{dni}")]
        public async Task<IActionResult> Get(string dni)
        {
            try
            {
                var employee = await _service.GetEmployeeByDni(dni);
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeDTO employee)
        {
            try
            {
                if (!IsValidForCreate(employee, out var error))
                {
                    throw new ArgumentException(error);
                }
                await _service.AddEmployee(employee);
                return Ok("Empleado creado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeDTO employee)
        {
            try
            {
                if (!IsValidForUpdate(employee, out var error))
                {
                    throw new ArgumentException(error);
                }
                if (id <= 0 || employee == null || employee.IdEmpleado <= 0 || id != employee.IdEmpleado)
                {
                    throw new ArgumentException("Id inválido o no coincide con el empleado.");
                }
                await _service.UpdateEmployee(employee);
                return Ok("Empleado actualizado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{dni}")]
        public async Task<IActionResult> Delete(string dni)
        {
            try
            {
                if (!IsValidForDelete(dni, out var error))
                {
                    throw new ArgumentException(error);
                }
                var employee = await _service.GetEmployeeByDni(dni);
                if (employee == null)
                {
                    return NotFound();
                }
                await _service.DeleteEmployee(employee.IdEmpleado);
                return Ok("Empleado eliminado correctamente");
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
    }
}

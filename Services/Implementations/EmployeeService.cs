using TP_ProgramaciónII_PIPORAMA.Data.DTOs;
using TP_ProgramaciónII_PIPORAMA.Data.DTOs.Invoice;
using TP_ProgramaciónII_PIPORAMA.Data.Models;
using TP_ProgramaciónII_PIPORAMA.Repositories.Interfaces;
using TP_ProgramaciónII_PIPORAMA.Services.Interfaces;

namespace TP_ProgramaciónII_PIPORAMA.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> ActivateEmployee(int id)
        {
            return await _repository.ActivateEmployee(id);
        }

        public async Task AddEmployee(EmployeeDTO employee)
        {
            try
            {
                var newEmployee = new Empleado
                {
                    IdEmpleado = employee.IdEmpleado,
                    DniEmpleado = employee.DniEmpleado,
                    NomEmpleado = employee.NomEmpleado,
                    ApeEmpleado = employee.ApeEmpleado,
                    Usuario = employee.Usuario,
                    Contrasenia = employee.Contrasenia,
                    IdBarrio = employee.Barrio.IdBarrio,
                    IdContacto = employee.Contacto.IdContacto,
                    IdRol = employee.Rol.IdRol,
                    Activo = true,
                    IdContactoNavigation = new Contacto
                    {
                        IdContacto = employee.Contacto.IdContacto,
                        Descripcion = employee.Contacto.Descripcion,
                        IdTipoContacto = employee.Contacto.IdTipoContacto
                    },
                    IdBarrioNavigation = new Barrio
                    {
                        IdBarrio = employee.Barrio.IdBarrio,
                        Descripcion = employee.Barrio.Descripcion
                    },
                    IdRolNavigation = new Role
                    {
                        IdRol = employee.IdRol,
                        Descripcion = employee.Rol.Descripcion
                    }
                };
                await _repository.AddEmployee(  newEmployee, 
                                                newEmployee.IdBarrioNavigation.Descripcion, 
                                                newEmployee.IdContactoNavigation, 
                                                newEmployee.IdRolNavigation.Descripcion 
                                                );
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el empleado", ex);
            }
        }

        public async Task DeleteEmployee(int id)
        {
            try
            {
                await _repository.DeleteEmployee(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el empleado", ex);
            }
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployees()
        {
            try
            {
                var employees = await _repository.GetAllEmployees();
                return employees.Select(e => new EmployeeDTO
                {
                    IdEmpleado = e.IdEmpleado,
                    DniEmpleado = e.DniEmpleado,
                    NomEmpleado = e.NomEmpleado,
                    ApeEmpleado = e.ApeEmpleado,
                    Usuario = e.Usuario,
                    Contrasenia = e.Contrasenia,
                    IdBarrio = e.IdBarrio,
                    IdContacto = e.IdContacto,
                    IdRol = e.IdRol,
                    Activo = e.Activo,
                    Barrio = e.IdBarrioNavigation is not null
                        ? new NeighborhoodDTO
                        {
                            IdBarrio = e.IdBarrioNavigation.IdBarrio,
                            Descripcion = e.IdBarrioNavigation.Descripcion
                        }
                        : null!,
                    Contacto = e.IdContactoNavigation is not null
                        ? new ContactDTO
                        {
                            IdContacto = e.IdContactoNavigation.IdContacto,
                            Descripcion = e.IdContactoNavigation.Descripcion,
                            IdTipoContacto = e.IdContactoNavigation.IdTipoContacto
                        }
                        : null!,
                    Rol = e.IdRolNavigation is not null
                        ? new RoleDTO
                        {
                            IdRol = e.IdRolNavigation.IdRol,
                            Descripcion = e.IdRolNavigation.Descripcion
                        }
                        : null!
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los empleados", ex);
            }
        }

        public async Task<EmployeeDTO?> GetEmployeeByDni(string dni)
        {
            try
            {
                var employee = await _repository.GetEmployeeByDni(dni);
                if (employee == null) return null;
                return new EmployeeDTO
                {
                    IdEmpleado = employee.IdEmpleado,
                    DniEmpleado = employee.DniEmpleado,
                    NomEmpleado = employee.NomEmpleado,
                    ApeEmpleado = employee.ApeEmpleado,
                    Usuario = employee.Usuario,
                    Contrasenia = employee.Contrasenia,
                    IdBarrio = employee.IdBarrio,
                    IdContacto = employee.IdContacto,
                    IdRol = employee.IdRol,
                    Activo = employee.Activo,
                    Barrio = employee.IdBarrioNavigation is not null
                        ? new NeighborhoodDTO
                        {
                            IdBarrio = employee.IdBarrioNavigation.IdBarrio,
                            Descripcion = employee.IdBarrioNavigation.Descripcion
                        }
                        : null!,
                    Contacto = employee.IdContactoNavigation is not null
                        ? new ContactDTO
                        {
                            IdContacto = employee.IdContactoNavigation.IdContacto,
                            Descripcion = employee.IdContactoNavigation.Descripcion,
                            IdTipoContacto = employee.IdContactoNavigation.IdTipoContacto
                        }
                        : null!,
                    Rol = employee.IdRolNavigation is not null
                        ? new RoleDTO
                        {
                            IdRol = employee.IdRolNavigation.IdRol,
                            Descripcion = employee.IdRolNavigation.Descripcion
                        }
                        : null!
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el empleado", ex);
            }
        }

        public async Task UpdateEmployee(EmployeeDTO employee)
        {
            try
            {
                var updatedEmployee = new Empleado
                {
                    IdEmpleado = employee.IdEmpleado,
                    DniEmpleado = employee.DniEmpleado,
                    NomEmpleado = employee.NomEmpleado,
                    ApeEmpleado = employee.ApeEmpleado,
                    Usuario = employee.Usuario,
                    Contrasenia = employee.Contrasenia,
                    IdBarrio = employee.IdBarrio,
                    IdContacto = employee.IdContacto,
                    IdRol = employee.IdRol,
                    Activo = employee.Activo
                };
                await _repository.UpdateEmployee(updatedEmployee);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el empleado", ex);
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using TP_ProgramaciónII_PIPORAMA.Data.Models;
using TP_ProgramaciónII_PIPORAMA.Repositories.Interfaces;

namespace TP_ProgramaciónII_PIPORAMA.Repositories.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PIPORAMAContext _context;
        public EmployeeRepository(PIPORAMAContext context)
        {
            _context = context;
        }

        public async Task<bool> ActivateEmployee(int id)
        {
            var client = await _context.Empleados.FindAsync(id);
            if (client == null)
            {
                return false;
            }
            client.Activo = true;
            _context.Empleados.Update(client);
            return await _context.SaveChangesAsync()>0;
        }

        public async Task AddEmployee(Empleado employee, string barrioNombre, Contacto contacto, string rol)
        {
            // insertar contacto y obtener su id
            _context.Contactos.Add(contacto);
            await _context.SaveChangesAsync();
            employee.IdContacto = contacto.IdContacto;

            // encontrar barrio con ese nombre y asignar id a empleado
            var barrio = await _context.Barrios.FirstOrDefaultAsync(b => b.Descripcion == barrioNombre);
            if (barrio == null)
                throw new Exception("Barriio no existe");
            employee.IdBarrio = barrio.IdBarrio;

            //encontrar rol y asignar id a empleado
            var rolFind = await _context.Roles.FirstOrDefaultAsync(r => r.Descripcion == rol);
            if (rolFind == null)
                throw new Exception("Rol no existe");
            employee.IdRol = rolFind.IdRol;

            // insertar empleado
            _context.Empleados.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await _context.Empleados.FindAsync(id);
            if (employee != null)
            {
                employee.Activo = false;
                _context.Empleados.Update(employee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Empleado>> GetAllEmployees()
        {
            return await _context.Empleados
                .Where(e => e.Activo)
                .Include(e => e.IdBarrioNavigation)
                .Include(e => e.IdContactoNavigation)
                .Include(e => e.IdRolNavigation)
                .ToListAsync();
        }

        public async Task<Empleado?> GetEmployeeByDni(string dni)
        {
            return await _context.Empleados.Include(e => e.IdBarrioNavigation)
                                           .Include(e => e.IdContactoNavigation)
                                           .FirstOrDefaultAsync(e => e.DniEmpleado == dni);
        }

        public async Task UpdateEmployee(Empleado employee)
        {
            _context.Empleados.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}

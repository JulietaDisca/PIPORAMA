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

        public async Task AddEmployee(Empleado employee, string barrioNombre, Contacto contacto)
        {
            // insertar contacto y obtener su id
            _context.Contactos.Add(contacto);
            await _context.SaveChangesAsync();
            employee.IdContacto = contacto.IdContacto;

            // encontrar barrio con ese nombre y asignar id a empleado
            var barrio = await _context.Barrios.FirstOrDefaultAsync(b => b.Descripcion == barrioNombre);   
            employee.IdBarrio = barrio.IdBarrio;

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
                .ToListAsync();
        }

        public async Task<Empleado?> GetEmployeeById(int id)
        {
            return await _context.Empleados.Include(e => e.IdBarrioNavigation)
                                           .Include(e => e.IdContactoNavigation)
                                           .FirstOrDefaultAsync(e => e.IdEmpleado == id);
        }

        public async Task UpdateEmployee(Empleado employee)
        {
            _context.Empleados.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}

using TP_ProgramaciónII_PIPORAMA.Data.Models;

namespace TP_ProgramaciónII_PIPORAMA.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Empleado>> GetAllEmployees();
<<<<<<< Updated upstream
        Task<Empleado?> GetEmployeeById(int id);
        Task AddEmployee(Empleado employee, string neighborhood, Contacto contact);
=======
        Task<Empleado?> GetEmployeeByDni(string dni);
        Task AddEmployee(Empleado employee, string neighborhood, Contacto contact, string rol);
>>>>>>> Stashed changes
        Task UpdateEmployee(Empleado employee);
        Task DeleteEmployee(int id);
    }
}

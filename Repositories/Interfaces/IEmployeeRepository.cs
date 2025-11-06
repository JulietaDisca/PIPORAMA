using TP_ProgramaciónII_PIPORAMA.Data.Models;

namespace TP_ProgramaciónII_PIPORAMA.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Empleado>> GetAllEmployees();
<<<<<<< HEAD
<<<<<<< Updated upstream
        Task<Empleado?> GetEmployeeById(int id);
=======
        Task<Empleado?> GetEmployeeByDni(string dni);
>>>>>>> 449827c1e31dda8f26915aca3efc34ae9d79533b
        Task AddEmployee(Empleado employee, string neighborhood, Contacto contact);
=======
        Task<Empleado?> GetEmployeeByDni(string dni);
        Task AddEmployee(Empleado employee, string neighborhood, Contacto contact, string rol);
>>>>>>> Stashed changes
        Task UpdateEmployee(Empleado employee);
        Task DeleteEmployee(int id);
        Task<bool> ActivateEmployee(int id);
    }
}

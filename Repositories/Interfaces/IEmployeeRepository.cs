using TP_ProgramaciónII_PIPORAMA.Data.Models;

namespace TP_ProgramaciónII_PIPORAMA.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Empleado>> GetAllEmployees();
        Task<Empleado?> GetEmployeeByDni(string dni);
        Task AddEmployee(Empleado employee, string neighborhood, Contacto contact);
        Task UpdateEmployee(Empleado employee);
        Task DeleteEmployee(int id);
    }
}

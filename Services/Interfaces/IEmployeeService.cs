using TP_ProgramaciónII_PIPORAMA.Data.DTOs.Invoice;


namespace TP_ProgramaciónII_PIPORAMA.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetAllEmployees();
        Task<EmployeeDTO?> GetEmployeeByDni(string dni);
        Task AddEmployee(EmployeeDTO employee);
        Task UpdateEmployee(EmployeeDTO employee);
        Task DeleteEmployee(int id);
        Task<bool> ActivateEmployee(int id);
    }
}

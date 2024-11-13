using Employee_Management_System.Models;

namespace Employee_Management_System.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> ListEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task AddEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
    }
}

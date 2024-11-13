using Employee_Management_System.Models;
using Employee_Management_System.Services;
namespace Employee_Management_System.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> ListEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task AddEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
    }
}

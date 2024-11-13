using Employee_Management_System.Models;
using Employee_Management_System.Repositories;

namespace Employee_Management_System.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> ListEmployeesAsync() =>
            await _employeeRepository.ListEmployeesAsync();

        public async Task<Employee> GetEmployeeByIdAsync(int id) =>
            await _employeeRepository.GetEmployeeByIdAsync(id);

        public async Task AddEmployeeAsync(Employee employee) =>
            await _employeeRepository.AddEmployeeAsync(employee);

        public async Task UpdateEmployeeAsync(Employee employee) =>
            await _employeeRepository.UpdateEmployeeAsync(employee);

        public async Task DeleteEmployeeAsync(int id) =>
            await _employeeRepository.DeleteEmployeeAsync(id);
    }
}

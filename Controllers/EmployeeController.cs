using Employee_Management_System.Models;
using Employee_Management_System.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Employee_Management_System.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // Action method for listing employees (renamed for consistency)
        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.ListEmployeesAsync();
            return View(employees); // Return the list of employees to the index view
        }

        // Action method for adding a new employee
        public IActionResult Create()
        {
            return View(); // Return the view to add a new employee
        }

        // Post method to handle the form submission for creating a new employee
        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.AddEmployeeAsync(employee);
                return RedirectToAction(nameof(Index)); // Redirect to the employee list page after adding
            }
            return View(employee); // If model is invalid, return the same view with error messages
        }

        // Action method for editing employee information
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
                return NotFound(); // Return 404 if employee is not found
            return View(employee); // Return the employee data to the Edit view
        }

        // Post method to handle the form submission for updating an employee
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
                return BadRequest(); // Return a bad request if ID mismatch

            if (ModelState.IsValid)
            {
                await _employeeService.UpdateEmployeeAsync(employee);
                return RedirectToAction(nameof(Index)); // Redirect to the employee list page after successful update
            }
            return View(employee); // Return the view with validation errors
        }

        // Action method for displaying employee details
        public async Task<IActionResult> Details(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                TempData["ErrorMessage"] = "Employee not found!";
                return RedirectToAction("Index"); // Redirect back to the list view
            }
            return View(employee); // Return the employee data to the Details view
        }

        // Action method for deleting an employee (shows confirmation)
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
                return NotFound(); // Return 404 if employee is not found
            return View(employee); // Return the employee data for deletion confirmation
        }

        // Post method to delete an employee after confirmation
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return RedirectToAction(nameof(Index)); // Redirect after successful deletion
        }
    }
}

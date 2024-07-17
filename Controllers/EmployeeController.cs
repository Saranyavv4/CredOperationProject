using ASP.NET_CRUD_Operation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_CRUD_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext _employeeContext;

        public EmployeeController(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext ?? throw new ArgumentNullException(nameof(employeeContext));
        }

        [HttpPost("CreateEmployee")]
        public async Task<Employee> CreateEmployee(Employee input)
        {
            _employeeContext.Employees.Add(input);
            await _employeeContext.SaveChangesAsync();
            return input;
        }

        [HttpGet("GetAllEmployee")]
        public async Task<List<Employee>> GetAllEmployee()
        {
            return await _employeeContext.Employees.ToListAsync();
        }

        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(Employee input)
        {
            var employee = await _employeeContext.Employees.FindAsync(input.Id);
            if (employee == null)
            {
                return NotFound();
            }
            employee.Name = input.Name;
            employee.Description = input.Description;
            await _employeeContext.SaveChangesAsync();

            return Ok();

        }

        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _employeeContext.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _employeeContext.Employees.Remove(employee);
            await _employeeContext.SaveChangesAsync();

            return Ok();
        }
    }
}

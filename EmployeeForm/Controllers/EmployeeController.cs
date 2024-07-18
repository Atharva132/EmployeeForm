using Microsoft.AspNetCore.Mvc;
using EmployeeForm.Models;
using EmployeeForm.Repository;
using Microsoft.AspNetCore.Cors;

namespace EmployeeForm.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {


        /* private static List<Employee> _employees = new List<Employee>
        {
            new Employee { FirstName = "Atharva", LastName = "Amte", EmployeeCode = 123, Contact = 2020, Address = "Dombivli", DoB = "18112000"}
        }; */

        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository) 
        {
            _employeeRepository = employeeRepository;
        }


        [HttpGet(Name = "GetEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}", Name = "EmployeeById")]
        public async Task<IActionResult> GetEmployeeById( int id )
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost(Name = "PostEmployees")]
        public async Task<IActionResult> CreateEmployee([FromBody]Employee employee)
        {
            try
            {
                var createdEmployee = await _employeeRepository.CreateEmployeeAsync(employee);
                return CreatedAtRoute("EmployeeById", new { id = createdEmployee.Id }, createdEmployee);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployees( int id, [FromBody]Employee employee)
        {
            var employeeExist = await GetEmployeeById(id);
            if (employeeExist == null) 
            { 
                return NotFound();
            }
            await _employeeRepository.UpdateEmployeeAsync(id, employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employeeExist = await GetEmployeeById(id);
            if (employeeExist == null)
            {
                return NotFound();
            }
            await _employeeRepository.DeleteEmployeeAsync(id);
            return NoContent();
        }
    }
}

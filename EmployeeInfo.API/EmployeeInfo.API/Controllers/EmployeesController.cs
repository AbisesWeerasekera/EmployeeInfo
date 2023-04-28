using EmployeeInfo.API.Models;
using EmployeeInfo.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeInfo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute]int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);

            if (employee == null) { 
            return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewEmployee([FromBody]EmployeeModel employeeModel)
        {
            var id = await _employeeRepository.AddEmployeeAsync(employeeModel);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = id, controller = "employees" }, id);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeModel employeeModel, [FromRoute]int id)
        {
            await _employeeRepository.UpdateEmployeeAsync(id,employeeModel);
            return Ok(); 
        }

        [HttpDelete("")]
        public async Task<IActionResult> DeleteEmployee([FromBody]int id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
            return Ok();
        }
    }
}

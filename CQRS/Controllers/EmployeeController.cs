using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS
{
        [ApiController]
        [Route("api/[Controller]")]
        public class EmployeeController : ControllerBase
        {
            private readonly EmployeeService _employeeService;

            public EmployeeController(EmployeeService employeeService)
            {
                _employeeService = employeeService;
            }
            [HttpPost]
            public async Task<ActionResult> CreateEmployee([FromBody] CreateCommand command)
            {
                await _employeeService.InsertEmployee(command);
                return Ok();
            }
            [HttpPatch("/update")]
            public async Task<ActionResult> UpdateEmployee([FromBody] UpdateCommand command)
            {
               await _employeeService.UpdateEmployee(command);
                return Ok();
            }
            [HttpGet("/find-by-job-tilte/{jobTilte}")]
            public async Task<ActionResult<List<GetEmployeeDto>>> GetEmployees(string jobTilte)
            {
                var query = new GetEmployeeQuery(){JobTilte = jobTilte};
                var employees = await _employeeService.GetEmployees(query);
                if (employees == null || employees.Count == 0)
                    return NotFound();
                return Ok(employees);
            }
            [HttpGet("/find-by-number/{employeeNumber}")]
            public async Task<ActionResult<GetEmployeeDto>> GetEmployee(string employeeNumber)
            {
            var query = new GetEmployeeQueryById(){EmployeeNumber = employeeNumber};
                var employee = await _employeeService.GetEmployee(query);
                if (employee == null)
                    return NotFound(query.EmployeeNumber);
                return Ok(employee);
            }
        }
}

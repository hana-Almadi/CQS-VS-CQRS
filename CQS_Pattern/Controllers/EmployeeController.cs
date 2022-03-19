

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CQS_Pattern
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeeController:ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService=employeeService;
        }
        [HttpPost("/create")]
        public ActionResult CreateEmployee([FromBody] CreateEmployeeDto createEmployeeDto)
        {
          _employeeService.InsertEmployee(createEmployeeDto);
          return Ok();
        }
        [HttpPatch("/update")]
        public ActionResult UpdateEmployee([FromBody] UpdateEmployeeDto updateEmployeeDto) 
        {
            _employeeService.UpdateEmployee(updateEmployeeDto);
            return Ok();
        }
        [HttpGet("/all")]
        public ActionResult<List<GetEmployeeDto>> GetEmployees()
        {
            var employees = _employeeService.GetEmployees();
            if (employees == null)
                return NotFound();
            return Ok(employees);
        }
        [HttpGet("/find-by-employee-id/{id}")]
        public ActionResult<GetEmployeeDto> GetEmployee(int id) {
         
            var employee= _employeeService.GetEmployee(id);
            if (employee == null)   
                return NotFound(id);
            return Ok(employee);
        
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using CrudApi.Models.Request;
using CrudApi.Models.DBModels;
using CrudApi.Repository.Interfaces;

namespace CrudApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            IEnumerable<Employee> employees = _employeeService.GetAllEmployees();
            return Ok(employees);
        }

       
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = _employeeService.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        } 

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeRequest addEmployeeRequest)
        {
            _employeeService.AddEmployee(addEmployeeRequest);

            return Ok("Employee Added Successfully");
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeRequest updateEmployeeRequest)
        {
            var isUpdated = _employeeService.UpdateEmployee(id, updateEmployeeRequest);

            if (isUpdated)
            {
                return Ok("Employee Updated successfully");
            }
            else
            {
                return NotFound("Employee not found");
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var isDeleted = _employeeService.DeleteEmployee(id);

            if (isDeleted)
            {
                return Ok("Employee deleted successfully");
            }
            else
            {
                return NotFound("Employee not found");
            }
        }  
    }
}

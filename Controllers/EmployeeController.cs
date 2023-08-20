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
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            //var employees = _employeeRepository.GetAll();
            IEnumerable<Employee> employees = _employeeRepository.GetAll();
            return Ok(employees);
        }

       
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = _employeeRepository.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        } 

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeRequest addEmployeeRequest)
        {
            var employee = new Employee
           {
               Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
               Email = addEmployeeRequest.Email,
               DOB = addEmployeeRequest.DOB.Date,
              CreatedDate = DateTime.Now,
              UpdatedDate = DateTime.Now
           };

         _employeeRepository.Add(employee);
         _unitOfWork.SaveChanges();

         return Ok(employee);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeRequest updateEmployeeRequest)
        {
            var employee = _employeeRepository.GetById(id);

            if (employee != null)
            {
                employee.Name = updateEmployeeRequest.Name;
                employee.Email = updateEmployeeRequest.Email;
                employee.DOB = updateEmployeeRequest.DOB.Date;
                employee.UpdatedDate = DateTime.Now;

                _employeeRepository.Update(employee);
                _unitOfWork.SaveChanges();

                return Ok(employee);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _employeeRepository.GetById(id);

            if (employee != null)
            {
                _employeeRepository.Delete(employee);
                _unitOfWork.SaveChanges();
                return Ok(employee);
            }

            return NotFound();
        }  
    }
}

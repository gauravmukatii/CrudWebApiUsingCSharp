using CrudApi.Data;
using CrudApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CrudApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly CrudApiDbContext dbContext;

        public EmployeesController(CrudApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            return Ok(await dbContext.Employees.ToListAsync());

        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetEmployeebyid([FromRoute] Guid id)
        {
            var employee = await dbContext.Employees.FindAsync(id);

            if(employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeeRequest addEmployeeRequest)
        {

            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                DOB = addEmployeeRequest.DOB.Date,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now

            };

            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, UpdateEmployeeRequest updateEmployeeRequest)
        {
            var employee = await dbContext.Employees.FindAsync(id);

            if (employee != null)
            {
                employee.Name = updateEmployeeRequest.Name;
                employee.Email = updateEmployeeRequest.Email;
                employee.DOB = updateEmployeeRequest.DOB.Date;
                employee.UpdatedDate = DateTime.Now;

                await dbContext.SaveChangesAsync();

                return Ok(employee);
            }

            return NotFound();

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await dbContext.Employees.FindAsync(id);

            if(employee != null)
            {
                dbContext.Remove(employee);
                await dbContext.SaveChangesAsync();
                return Ok(employee);
            }

            return NotFound();

        }
    
    
    }
}

using CrudApi.Models.DBModels;
using CrudApi.Models.Request;

namespace CrudApi.Repository.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(Guid id);
        void AddEmployee(AddEmployeeRequest addEmployeeRequest);
        bool UpdateEmployee(Guid id, UpdateEmployeeRequest updateEmployeeRequest);
        bool DeleteEmployee(Guid id);
      
    }
}

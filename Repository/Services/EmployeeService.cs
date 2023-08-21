using Azure;
using CrudApi.Models.DBModels;
using CrudApi.Models.Request;
using CrudApi.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System;

namespace CrudApi.Repository.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _unitOfWork.EmployeeRepository.GetAll();
        }

        public Employee GetEmployeeById(Guid id) {

            return _unitOfWork.EmployeeRepository.GetById(id);
        }

        public void AddEmployee(AddEmployeeRequest addEmployeeRequest)
        {
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Email = addEmployeeRequest.Email,
                DOB = DateTime.Now,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };

            _unitOfWork.EmployeeRepository.Add(employee);
            _unitOfWork.SaveChanges();

        }

        public bool UpdateEmployee(Guid id, UpdateEmployeeRequest updateEmployeeRequest) {

                var employee = _unitOfWork.EmployeeRepository.GetById(id);

                if (employee != null)
                {
                    employee.Name = updateEmployeeRequest.Name;
                    employee.Email = updateEmployeeRequest.Email;
                    employee.DOB = updateEmployeeRequest.DOB;
                    employee.UpdatedDate = DateTime.Now;

                    _unitOfWork.EmployeeRepository.Update(employee);
                    return true;

                }
                return false;
            }


        public bool DeleteEmployee(Guid id)
        {
            var employee = _unitOfWork.EmployeeRepository.GetById(id);

            if (employee != null)
            {
                _unitOfWork.EmployeeRepository.Delete(employee);
                _unitOfWork.SaveChanges();
                return true;
            }
            return false;
        }



    }
}

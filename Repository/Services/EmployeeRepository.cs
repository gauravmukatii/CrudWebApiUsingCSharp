using CrudApi.Data;
using CrudApi.Models.DBModels;
using CrudApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Repository.Services
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(CrudApiDbContext dbContext) : base(dbContext)
        {
        }
    }
}


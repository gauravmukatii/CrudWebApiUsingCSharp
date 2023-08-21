using CrudApi.Data;
using CrudApi.Repository.Interfaces;

namespace CrudApi.Repository.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CrudApiDbContext _dbContext;

        public UnitOfWork(CrudApiDbContext dbContext)
        {
            _dbContext = dbContext;
            EmployeeRepository = new EmployeeRepository(_dbContext);
        }

        public IEmployeeRepository EmployeeRepository { get;  }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}

using CrudApi.Data;
using CrudApi.Repository.Interfaces;

namespace CrudApi.Repository.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CrudApiDbContext _dbcontext;

        public UnitOfWork(CrudApiDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void SaveChanges()
        {
            _dbcontext.SaveChanges();
        }
    }
}

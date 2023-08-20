using CrudApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbContext _dbContext;

    public Repository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public T GetById(Guid id)
    {
        return _dbContext.Set<T>().Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return _dbContext.Set<T>().ToList();
    }

    public void Add(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        _dbContext.SaveChanges();
    }

    public void Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        _dbContext.SaveChanges();
    }

    public void Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        _dbContext.SaveChanges();
    }
}

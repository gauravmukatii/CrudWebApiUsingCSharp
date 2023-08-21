namespace CrudApi.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; }
        void SaveChanges();
    }
}

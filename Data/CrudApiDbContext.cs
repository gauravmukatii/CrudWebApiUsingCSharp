using CrudApi.Models.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace CrudApi.Data
{
    public class CrudApiDbContext : DbContext
    {
        public CrudApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}

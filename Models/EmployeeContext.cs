using Microsoft.EntityFrameworkCore;

namespace ASP.NET_CRUD_Operation.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> dbContextOptions)
        : base(dbContextOptions) { }
        public DbSet<Employee> Employees { get; set; } 
    }
}

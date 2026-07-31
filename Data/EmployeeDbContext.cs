using EmployeeManagement.Api.Models;
using Microsoft.EntityFrameworkCore;


namespace EmployeeManagement.Api.Data;

public class EmployeeDbContext : DbContext
{
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) 
        : base(options)
    {
    }

    public DbSet<Employee> Employees => Set<Employee>();
}

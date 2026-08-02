using EmployeeManagement.Api.Models;
using EmployeeManagement.Api.Services;
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

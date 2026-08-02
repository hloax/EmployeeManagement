using EmployeeManagement.Api.Models;
using EmployeeManagement.Api.Data;
using EmployeeManagement.Api.Dtos;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Services;

public class EmployeeService : IEmployeeService
{
  
    private readonly EmployeeDbContext _context;

    public EmployeeService(EmployeeDbContext context)
    {
        _context = context;
    }
    public async Task<List<Employee>> GetEmployeesAsync()
    {
        return await _context.Employees.ToListAsync();
    }

    public Employee? GetEmployeeById(int id)
    {
        return _context.Employees.
            FirstOrDefault(e => e.Id == id);
    }

    public List<Employee> GetHighEarners()
    {
        return _context.Employees
            .Where(e => e.Salary > 50000)
            .ToList();
    }

    public List<Employee> GetEmployeesByDepartment(string department)
    {
        return _context.Employees
           .Where(e => e.Department == department)
           .ToList();
    }

    public List<Employee> GetEmployeesOrderedBySalary()
    {
        return _context.Employees
            .OrderByDescending(e => e.Salary)
            .ToList();
    }

    public async Task<Employee> CreateEmployeeAsync(CreateEmployeeDto createEmployee)
    {
        var employee = new Employee
        {

            FirstName = createEmployee.FirstName,
            LastName = createEmployee.LastName,
            Email = createEmployee.Email,
            Salary = createEmployee.Salary,
            Department = createEmployee.Department
        };

        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();

        return employee;
    }
}

using EmployeeManagement.Api.Models;
using EmployeeManagement.Api.Data;
using EmployeeManagement.Api.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

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

    public async Task<Employee?> GetEmployeeByIdAsync(int id)
    {
        return await _context.Employees.FindAsync(id);
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

    public async Task<Employee?> UpdateEmployeeAsync(int id, UpdateEmployeeDto dto)
    {
        var employee = await _context.Employees.FindAsync(id);

        if (employee == null)
        {
            return null;
        }

        employee.FirstName = dto.FirstName;
        employee.LastName = dto.LastName;
        employee.Email = dto.Email;
        employee.Department = dto.Department;
        employee.Salary = dto.Salary;

        await _context.SaveChangesAsync();

        return employee;
    }

    public async Task<Employee?> PatchEmployeeAsync(int id, PatchEmployeeDto dto)
    {
        var employee = await _context.Employees.FindAsync(id);

        if (employee == null)
        {
            return null;
        }

        if (dto.FirstName != null)
        {
            employee.FirstName = dto.FirstName;
        }

        if (dto.LastName != null)
        {
            employee.LastName = dto.LastName;
        }

        if (dto.Email != null)
        {
            employee.Email = dto.Email;
        }

        if (dto.Salary.HasValue)
        {
            employee.Salary = dto.Salary.Value;
        }

        if (dto.Department != null)
        {
            employee.Department = dto.Department;
        }

        await _context.SaveChangesAsync();

        return employee;
    }

    public async Task<bool> DeleteEmployeeAsync(int id)
    {
        var employee = await _context.Employees.FindAsync(id);

        if (employee == null)
        {
            return false;
        }

        _context.Employees.Remove(employee);

        await _context.SaveChangesAsync();

        return true;
    }
}

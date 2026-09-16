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
    public async Task<List<EmployeeResponseDto>> GetEmployeesAsync()
    {
        var employees = await _context.Employees.ToListAsync();

        return employees
            .Select(MapToResponse)
            .ToList();
    }

    public async Task<EmployeeResponseDto?> GetEmployeeByIdAsync(int id)
    {
        var employee = await _context.Employees.FindAsync(id);

        if (employee == null)
        {
            return null;
        }

        return MapToResponse(employee);
    }

    public List<EmployeeResponseDto> GetHighEarners()
    {
        var employee = _context.Employees
            .Where(e => e.Salary > 50000)
            .ToList();

        return employee
            .Select(MapToResponse)
            .ToList();
    }

    public List<EmployeeResponseDto> GetEmployeesByDepartment(string department)
    {
        var employee = _context.Employees
           .Where(e => e.Department == department)
           .ToList();

        return employee
            .Select(MapToResponse)
            .ToList();
    }

    public List<EmployeeResponseDto> GetEmployeesOrderedBySalary()
    {
        var employee = _context.Employees
            .OrderByDescending(e => e.Salary)
            .ToList();

        return employee
            .Select(MapToResponse)
            .ToList();
    }

    public async Task<EmployeeResponseDto> CreateEmployeeAsync(CreateEmployeeDto createEmployee)
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

        return MapToResponse(employee);
    }

    public async Task<EmployeeResponseDto?> UpdateEmployeeAsync(int id, UpdateEmployeeDto dto)
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

        return MapToResponse(employee);
    }

    public async Task<EmployeeResponseDto?> PatchEmployeeAsync(int id, PatchEmployeeDto dto)
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

        return MapToResponse(employee);
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


    private EmployeeResponseDto MapToResponse(Employee employee)
    {
        return new EmployeeResponseDto
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            Salary = employee.Salary,
            Department = employee.Department,
            CreatedAt = employee.CreatedAt,
            UpdatedAt = employee.UpdatedAt
        };
    }
}

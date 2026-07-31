using EmployeeManagement.Api.Models;

namespace EmployeeManagement.Api.Services;

public class EmployeeService : IEmployeeService
{
    private readonly List<Employee> _employees =
    [
        new Employee
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            Email = "john@test.com",
            Salary = 60000,
            Department = "IT"
        },

        new Employee
        {
            Id = 2,
            FirstName = "Jane",
            LastName = "Smith",
            Email = "jane@test.com",
            Salary = 45000,
            Department = "Finance"
        },

        new Employee
        {
            Id = 3,
            FirstName = "Paul",
            LastName = "Johnson",
            Email = "paul@test.com",
            Salary = 35000,
            Department = "HR"
        },

        new Employee
        {
            Id = 4,
            FirstName = "Mike",
            LastName = "Brown",
            Email = "mike@test.com",
            Salary = 80000,
            Department = "IT"
        }
    ];
    public Task<List<Employee>> GetEmployeesAsync()
    {
        return Task.FromResult(_employees);
    }

    public Employee? GetEmployeeById(int id)
    {
        return _employees.
            FirstOrDefault(e => e.Id == id);
    }

    public List<Employee> GetHighEarners()
    {
        return _employees
            .Where(e => e.Salary > 50000)
            .ToList();
    }

    public List<Employee> GetEmployeesByDepartment(string department)
    {
        return _employees
           .Where(e => e.Department == department)
           .ToList();
    }

    public List<Employee> GetEmployeesOrderedBySalary()
    {
        return _employees
            .OrderByDescending(e => e.Salary)
            .ToList();
    }
}

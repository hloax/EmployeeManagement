using EmployeeManagement.Api.Models;
using EmployeeManagement.Api.Dtos;

namespace EmployeeManagement.Api.Services;

public interface IEmployeeService
{
    Task<List<Employee>> GetEmployeesAsync();
    Employee? GetEmployeeById(int id);
    List<Employee> GetHighEarners();
    List<Employee> GetEmployeesByDepartment(string department);
    List<Employee> GetEmployeesOrderedBySalary();
    Task<Employee> CreateEmployeeAsync(CreateEmployeeDto createEmployee);
}

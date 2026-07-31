using EmployeeManagement.Api.Models;

namespace EmployeeManagement.Api.Services;

public interface IEmployeeService
{
    Task<List<Employee>> GetEmployeesAsync();
    Employee? GetEmployeeById(int id);
    List<Employee> GetHighEarners();
    List<Employee> GetEmployeesByDepartment(string department);
    List<Employee> GetEmployeesOrderedBySalary();
}

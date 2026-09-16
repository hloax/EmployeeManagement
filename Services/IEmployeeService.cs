using EmployeeManagement.Api.Dtos;

namespace EmployeeManagement.Api.Services;

public interface IEmployeeService
{
    Task<List<EmployeeResponseDto>> GetEmployeesAsync();
    Task<EmployeeResponseDto?> GetEmployeeByIdAsync(int id);
    List<EmployeeResponseDto> GetHighEarners();
    List<EmployeeResponseDto> GetEmployeesByDepartment(string department);
    List<EmployeeResponseDto> GetEmployeesOrderedBySalary();
    Task<EmployeeResponseDto> CreateEmployeeAsync(CreateEmployeeDto createEmployee);
    Task<EmployeeResponseDto?> UpdateEmployeeAsync(int id, UpdateEmployeeDto dto);
    Task<EmployeeResponseDto?> PatchEmployeeAsync(int id, PatchEmployeeDto dto);
    Task<bool> DeleteEmployeeAsync(int id);

}

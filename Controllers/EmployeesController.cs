using EmployeeManagement.Api.Dtos;
using EmployeeManagement.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        /*var employees = await _employeeService.GetEmployeesAsync();

        return Ok(employees);*/
        return Ok(await _employeeService.GetEmployeesAsync());
    }

    [HttpGet("{id}")]
    public IActionResult GetEmploeeById(int id)
    {
        var employee = _employeeService.GetEmployeeById(id);

        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);
    }

    [HttpGet("high-earners")]
    public IActionResult GetHighEarningEmployees()
    {
        return Ok(_employeeService.GetHighEarners());
    }

    [HttpGet("department/{department}")]
    public IActionResult GetEmployeesByDepartment(string department)
    {        
        return Ok(_employeeService.GetEmployeesByDepartment(department));
    }

    [HttpGet("by-salary")]
    public IActionResult GetEmployeesOrderedBySalary()
    {
        return Ok(_employeeService.GetEmployeesOrderedBySalary());
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody]CreateEmployeeDto createEmployee)
    {
        return Ok(await _employeeService.CreateEmployeeAsync(createEmployee));
    }
}

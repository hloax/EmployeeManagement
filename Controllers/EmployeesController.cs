using EmployeeManagement.Api.Dtos;
using EmployeeManagement.Api.Models;
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
        return Ok(await _employeeService.GetEmployeesAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmploeeById(int id)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(id);

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
        var employee = await _employeeService.CreateEmployeeAsync(createEmployee);

        return CreatedAtAction(
            nameof(GetEmploeeById),
            new { id = employee.Id },
            employee
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(int id, UpdateEmployeeDto dto)
    {
        var employee = await _employeeService.UpdateEmployeeAsync(id, dto);

        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchEmployee(int id, PatchEmployeeDto dto)
    {
        var employee = await _employeeService.PatchEmployeeAsync(id, dto);

        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);
    }
}

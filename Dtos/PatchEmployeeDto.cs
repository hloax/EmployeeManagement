namespace EmployeeManagement.Api.Dtos;

public class PatchEmployeeDto
{
    public string? FirstName { get; set; }
    public string? LastName {get; set; }
    public string? Email { get; set; }
    public decimal? Salary { get; set; }
    public string? Department { get; set; }
}

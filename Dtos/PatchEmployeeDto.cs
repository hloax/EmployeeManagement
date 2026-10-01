using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace EmployeeManagement.Api.Dtos;

public class PatchEmployeeDto
{
    [StringLength(100)]
    public string? FirstName { get; set; }

    [StringLength(100)]
    public string? LastName {get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    [Range(1, 1_000_000)]
    public decimal? Salary { get; set; }

    public string? Department { get; set; }
}

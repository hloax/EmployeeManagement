using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Api.Dtos;

public class CreateEmployeeDto
{
    [Required]
    [StringLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set;  } = string.Empty;

    [Range(0, double.MaxValue)]
    public decimal Salary { get; set;  }

    [Required]
    public string Department { get; set; } = string.Empty;
}

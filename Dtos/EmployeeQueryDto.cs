using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Api.Dtos;

public class EmployeeQueryDto
{
    [Range(1, int.MaxValue)]
    public int Page { get; set; } = 1;

    [Range(1, 100)]
    public int PageSize { get; set; } = 20;

    public string? Department { get; set; }

    public string? SortBy { get; set; }

    public bool Descending { get; set; } = false;

}

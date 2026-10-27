using EmployeeManagement.Api.Models;

namespace EmployeeManagement.Api.Extensions;

public static class EmployeeExtensions
{
    public static string GetDisplayName(this Employee employee)
    {
        return $"{employee.FirstName} {employee.LastName} ({employee.Department})";
    }
}

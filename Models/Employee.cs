namespace EmployeeManagement.Api.Models;

public class Employee : BaseEntity
{

    public string FirstName { get; set; } = "";

    public string LastName { get; set; } = "";

    public string Email { get; set; } = "";

    public decimal Salary { get; set; }

    public string Department { get; set; } = "";

    public string FullName => $"{FirstName} {LastName}";

    public bool IsHighEarner => Salary > 50000;
}

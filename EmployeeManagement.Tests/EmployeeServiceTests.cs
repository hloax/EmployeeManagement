using EmployeeManagement.Api.Data;
using EmployeeManagement.Api.Dtos;
using EmployeeManagement.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Tests
{
    public class EmployeeServiceTests
    {
        [Fact]
        public async Task CreateEmployeeAsync_ValidEmployee_ReturnsCreatedEmployee()
        {

            var options = new DbContextOptionsBuilder<EmployeeDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            await using var context = new EmployeeDbContext(options);

            var service = new EmployeeService(context);

            var dto = new CreateEmployeeDto
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Salary = 25000m,
                Department = "HR"
            };

            var result = await service.CreateEmployeeAsync(dto);

            Assert.NotNull(result);
            Assert.Equal("John", result.FirstName);
            Assert.Equal("Doe", result.LastName);
            Assert.Equal("john.doe@example.com", result.Email);
            Assert.Equal(25000m, result.Salary);
            Assert.Equal("HR", result.Department);
            Assert.True(result.Id > 0);
        }

        [Fact]
        public async Task GetEmployeeByIdAsync_NonExistingId_ReturnsNull()
        {

            var options = new DbContextOptionsBuilder<EmployeeDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            await using var context = new EmployeeDbContext(options);

            var service = new EmployeeService(context);

            var result = await service.GetEmployeeByIdAsync(999);

            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateEmployeeAsync_ExistingEmployee_UpdatesEmployee()
        {

            var options = new DbContextOptionsBuilder<EmployeeDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            await using var context = new EmployeeDbContext(options);

            var service = new EmployeeService(context);

            var createDto = new CreateEmployeeDto
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Salary = 25000m,
                Department = "HR"
            };

            var createdEmployee = await service.CreateEmployeeAsync(createDto);

            var updateDto = new UpdateEmployeeDto
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Salary = 35000m,
                Department = "Finance"
            };

            var updatedEmployee = await service.UpdateEmployeeAsync(
                createdEmployee.Id, updateDto);

            Assert.NotNull(updatedEmployee);
            Assert.Equal(35000m, updatedEmployee.Salary);
            Assert.Equal("Finance", updatedEmployee.Department);
        }

        [Fact]
        public async Task DeleteEmployeeAsync_ExistingEmployee_True()
        {

            var options = new DbContextOptionsBuilder<EmployeeDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            await using var context = new EmployeeDbContext(options);

            var service = new EmployeeService(context);

            var createDto = new CreateEmployeeDto
            {
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@example.com",
                Salary = 50000m,
                Department = "IT"
            };

            var createdEmployee = await service.CreateEmployeeAsync(createDto);

            var deleted = await service.DeleteEmployeeAsync(createdEmployee.Id);

            Assert.True(deleted);
            Assert.False(await context.Employees.AnyAsync(
                e => e.Id == createdEmployee.Id));
        }
    }
}

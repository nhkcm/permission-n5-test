using Microsoft.EntityFrameworkCore;
using N5Test.Database;
using N5Test.Database.models;
using N5TLTest.Commands.Employee;

namespace N5TLTest.Database.repositories
{
    public class EmployeeRepositoty : IEmployeeRepository
    {
        private readonly N5CompanyContext _ctx;
        public EmployeeRepositoty(N5CompanyContext n5)
        {
            _ctx = n5;
        }

        public async Task Add(AddEmployeeCommand command) {
            await _ctx.Employees.AddAsync(new Employee
            {
                Id = command.Id,
                FirstName = command.FirstName ?? "",
                LastName = command.LastName ?? "",
            });
            _ctx.SaveChanges();
        }

        public async Task<List<Employee>> GetAllEmployees() {
            return await _ctx.Employees.ToListAsync();
        }

        public async Task<List<Employee>> GetEmployeesByPermissionType(string permissionType)
        {
            return await _ctx.Employees
                .Where(w => w.PermissionTypes.Any(p => p.Description  == permissionType))
                .ToListAsync();
        }
    }
}

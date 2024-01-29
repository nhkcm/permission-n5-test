using N5Test.Database.models;
using N5TLTest.Commands.Employee;

namespace N5TLTest.Database.repositories
{
    public interface IEmployeeRepository
    {
        Task Add(AddEmployeeCommand command);

        Task<List<Employee>> GetAllEmployees();

        Task<List<Employee>> GetEmployeesByPermissionType(string permissionType);
    }
}

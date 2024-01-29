using N5TLTest.Commands;
using N5TLTest.Commands.Employee;
using N5TLTest.Database.repositories;
using N5TLTest.Dtos;

namespace N5TLTest.Handlers
{
    public class EmployeesCommandHandler : ICommandHandler<AddEmployeeCommand>, IQuery<List<EmployeeResponse>, GetEmployeeCommand>
    {
        private readonly IEmployeeRepository _employeeRepositoty;
        private readonly ILogger<EmployeesCommandHandler> _logger;
        public EmployeesCommandHandler(
            IEmployeeRepository employeeRepositoty,
            ILogger<EmployeesCommandHandler> logger)
        {
            _logger = logger;
            _employeeRepositoty = employeeRepositoty;
        }

        public async Task Handle(AddEmployeeCommand command)
        {
            await _employeeRepositoty.Add(command);
            _logger.LogInformation("employee created with id: {@id}", command.Id);
        }

        public async Task<List<EmployeeResponse>> Query(GetEmployeeCommand param)
        {
            if (string.IsNullOrEmpty(param.PermissionType))
            {
                return (await _employeeRepositoty.GetAllEmployees())
                        .Select(s => new EmployeeResponse
                        {
                            Id = s.Id,
                            FirstName = s.FirstName,
                            LastName = s.LastName
                        }).ToList();
            }
            else
            {
                return (await _employeeRepositoty.GetEmployeesByPermissionType(param.PermissionType))
                        .Select(s => new EmployeeResponse
                        {
                            Id = s.Id,
                            FirstName = s.FirstName,
                            LastName = s.LastName
                        }).ToList();
            }
        }
    }
}

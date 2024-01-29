using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using N5TLTest.Commands.Employee;
using N5TLTest.Dtos;
using N5TLTest.Handlers;

namespace N5TLTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeesCommandHandler _employeesCommandHandler;
        public EmployeeController(EmployeesCommandHandler employeesCommandHandler)
        {
            _employeesCommandHandler = employeesCommandHandler;
        }

        [HttpPost("query")]        
        public async Task<List<EmployeeResponse>> GetEmployees(GetEmployeeCommand command)
        {
            return await _employeesCommandHandler.Query(command);
        }



        [HttpPost]
        public async Task CreateEmployee(AddEmployeeCommand command)
        {
            await _employeesCommandHandler.Handle(command);
        }

    }
}

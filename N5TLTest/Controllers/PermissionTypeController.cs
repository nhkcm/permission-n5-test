using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using N5TLTest.Commands.Employee;
using N5TLTest.Commands.PermissionType;
using N5TLTest.Handlers;

namespace N5TLTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypeController : ControllerBase
    {
        private readonly PermissionTypeCommandHandler _permisionTypeCommandHandler;
        public PermissionTypeController(PermissionTypeCommandHandler permisionTypeCommandHandler)
        {
            _permisionTypeCommandHandler = permisionTypeCommandHandler; 
        }

        [HttpPost]
        public async Task CreateEmployee(AddPermissionTypeCommand command)
        {
            await _permisionTypeCommandHandler.Handle(command);
        }
    }
}

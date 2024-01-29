using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using N5TLTest.Commands.Permissions;
using N5TLTest.Handlers;

namespace N5TLTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisionController : ControllerBase
    {
        private readonly PermissionCommandHandler _permissionCommandHandler;

        public PermisionController(PermissionCommandHandler permissionCommandHandler)
        {
            _permissionCommandHandler = permissionCommandHandler;
        }

        [HttpPost]
        public async Task CreatePermission(AddPermissionCommand command) { 
            await _permissionCommandHandler.Handle(command);
        }
    }
}

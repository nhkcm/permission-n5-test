using Microsoft.Extensions.Logging;
using Moq;
using N5TLTest.Commands.Employee;
using N5TLTest.Commands.Permissions;
using N5TLTest.Database.repositories;
using N5TLTest.Handlers;
using N5TLTest.Handlers.ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5Test
{
    internal class PermissionTest
    {
        [Test]
        public async Task TestAddEmployees()
        {

            var logger = new Mock<ILogger<PermissionCommandHandler>>() ?? throw new Exception("not initializaced");
            var permissionRepository = new Mock<IPermissionRepository>() ?? throw new Exception("not initializaced");
            var eventBroker = new Mock<IEventBrokerService>() ?? throw new Exception("not initializaced");
            var searchEngineService = new Mock<ISearchEngineService>() ?? throw new Exception("not initializaced");

            var guid = Guid.NewGuid();

            permissionRepository.Setup(x => x.Add(It.IsAny<AddPermissionCommand>())).Returns(Task.FromResult(() => { }));

            var permissionCommandHandler = new PermissionCommandHandler(
                permissionRepository.Object, 
                logger.Object, 
                eventBroker.Object, 
                searchEngineService.Object
            );

            await permissionCommandHandler.Handle(new AddPermissionCommand { 
                Id = guid,
                Description = "Test", 
                TypeId = Guid.NewGuid()
            });

            permissionRepository.Verify(mock => mock.Add(It.IsAny<AddPermissionCommand>()), Times.Once());
        }
    }
}

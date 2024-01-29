using N5TLTest.Commands;
using N5TLTest.Commands.PermissionType;
using N5TLTest.Database.repositories;
using N5TLTest.Handlers.ports;

namespace N5TLTest.Handlers
{
    public class PermissionTypeCommandHandler : ICommandHandler<AddPermissionTypeCommand>
    {
        private readonly ILogger<PermissionCommandHandler> _logger;
        private readonly PermissionTypeRepository _repository;
        private readonly IEventBrokerService _eventBrokerService;

        public PermissionTypeCommandHandler(
            PermissionTypeRepository repository,
            ILogger<PermissionCommandHandler> logger,
            IEventBrokerService eventBroker) {

            _repository = repository;
            _logger = logger;
            _eventBrokerService = eventBroker;
        }

        public async Task Handle(AddPermissionTypeCommand command)
        {
            await _repository.Add(command);
            _logger.LogInformation("permission type created");

            await _eventBrokerService.SendEvent("permission type created");
        }
    }
}

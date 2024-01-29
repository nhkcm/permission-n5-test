using N5TLTest.Commands.Employee;
using N5TLTest.Commands;
using N5TLTest.Dtos;
using N5TLTest.Commands.Permissions;
using N5TLTest.Database.repositories;
using N5TLTest.Handlers.ports;

namespace N5TLTest.Handlers
{
    public class PermissionCommandHandler : 
        ICommandHandler<AddPermissionCommand>,
        IQuery<List<PermissionResponse>, GetPermissionByTypeCommand>
    {
        private readonly ILogger<PermissionCommandHandler> _logger;
        private readonly IPermissionRepository _repository;
        private readonly IEventBrokerService _eventBrokerService;
        private readonly ISearchEngineService _searchEngineService;

        public PermissionCommandHandler(
            IPermissionRepository repository,
            ILogger<PermissionCommandHandler> logger,
            IEventBrokerService eventBroker,
            ISearchEngineService searchEngineService)
        { 
            _repository = repository;
            _logger = logger;
            _eventBrokerService = eventBroker;
            _searchEngineService = searchEngineService;
        }

        public async Task Handle(AddPermissionCommand command)
        {
            await _repository.Add(command);
            _logger.LogInformation("permission created");

            await _eventBrokerService.SendEvent("create permission");
            _logger.LogInformation("event emited");

            await _searchEngineService.AddToIndex(command);
            _logger.LogInformation("index created");
        }

        public async Task<List<PermissionResponse>> Query(GetPermissionByTypeCommand param)
        {               
            await _eventBrokerService.SendEvent("query permission by type");

            _logger.LogInformation($"permissions queried by {param.permissionTypeName}");

            return await _repository.GetPermissionByType(param);
        }
    }
}

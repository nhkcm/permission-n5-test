using N5TLTest.Commands.Permissions;

namespace N5TLTest.Handlers.ports
{
    public interface ISearchEngineService
    {
        Task AddToIndex(AddPermissionCommand command);
    }
}

using N5Test.Database.models;
using N5TLTest.Commands.Permissions;
using N5TLTest.Dtos;

namespace N5TLTest.Database.repositories
{
    public interface IPermissionRepository
    {
        Task Add(AddPermissionCommand command);

        Task<List<PermissionResponse>> GetPermissionByType(GetPermissionByTypeCommand command);
    }
}

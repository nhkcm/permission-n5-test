using N5Test.Database;
using N5Test.Database.models;
using N5TLTest.Commands.Permissions;
using N5TLTest.Commands.PermissionType;

namespace N5TLTest.Database.repositories
{
    public class PermissionTypeRepository
    {
        private readonly N5CompanyContext _ctx;

        public PermissionTypeRepository(N5CompanyContext n5)
        {
            _ctx = n5;
        }

        public async Task Add(AddPermissionTypeCommand command)
        {
            await _ctx.PermissionTypes.AddAsync(new PermissionType
            {
                Id = command.Id,
                Description = command.Description ?? ""
            });
            _ctx.SaveChanges();
        }
    }
}

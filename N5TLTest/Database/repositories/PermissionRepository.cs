using Microsoft.EntityFrameworkCore;
using N5Test.Database;
using N5Test.Database.models;
using N5TLTest.Commands.Employee;
using N5TLTest.Commands.Permissions;
using N5TLTest.Dtos;

namespace N5TLTest.Database.repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly N5CompanyContext _ctx;

        public PermissionRepository(N5CompanyContext n5)
        {
            _ctx = n5;
        }

        public async Task Add(AddPermissionCommand command)
        {
            await _ctx.Permissions.AddAsync(new Permission
            {
                Id = command.Id,
                Description = command.Description ?? "",
                PermissionTypeId = command.TypeId
            });
            _ctx.SaveChanges();
        }        

        public async Task<List<PermissionResponse>> GetPermissionByType(GetPermissionByTypeCommand command)
        {
            return await _ctx.Permissions
                .Where(w => w.PermissionType.Description == command.permissionTypeName)
                .Select(s => new PermissionResponse() { 
                    Id = s.Id, 
                    Description = s.Description ?? "", 
                    Type = s.PermissionType.Description 
                })
                .ToListAsync();
        }
    }
}

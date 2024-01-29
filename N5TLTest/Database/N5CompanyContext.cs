using Microsoft.EntityFrameworkCore;
using N5Test.Database.models;
using System.Diagnostics;

namespace N5Test.Database
{
    public class N5CompanyContext : DbContext
    {

        public N5CompanyContext(DbContextOptions<N5CompanyContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }
    }
}

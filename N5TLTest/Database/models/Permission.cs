namespace N5Test.Database.models
{
    public class Permission
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public Guid PermissionTypeId { get; set; }        

        public PermissionType PermissionType { get; set; }
    }
}

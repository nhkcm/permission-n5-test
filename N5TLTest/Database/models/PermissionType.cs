namespace N5Test.Database.models
{
    public class PermissionType
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public List<Employee>? Employees { get; set; }
    }
}

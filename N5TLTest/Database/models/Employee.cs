namespace N5Test.Database.models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<PermissionType> PermissionTypes { get; set; }
    }
}

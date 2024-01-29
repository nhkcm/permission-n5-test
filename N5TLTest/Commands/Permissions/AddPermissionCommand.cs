namespace N5TLTest.Commands.Permissions
{
    public class AddPermissionCommand
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public Guid TypeId { get; set; }
    }
}

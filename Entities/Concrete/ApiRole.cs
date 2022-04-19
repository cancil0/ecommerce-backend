namespace Entities.Concrete
{
    public class ApiRole
    {
        public Guid ApiId { get; set; }
        public Api Api { get; set; }

        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}

namespace Entities.Concrete
{
    public class Role
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }

        public List<ApiRole> ApiRoles { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}

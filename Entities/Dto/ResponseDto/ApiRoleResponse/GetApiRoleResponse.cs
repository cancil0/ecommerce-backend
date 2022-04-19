namespace Entities.Dto.ResponseDto.ApiRoleResponse
{
    public class GetApiRoleResponse
    {
        public Guid ApiId { get; set; }
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public string ApiRoutePath { get; set; }
    }
}

namespace Entities.Concrete
{
    public class Api
    {
        public Guid ApiId { get; set; }
        public string ApiRoute { get; set; }
        public List<ApiRole> ApiRoles { get; set; }
    }
}

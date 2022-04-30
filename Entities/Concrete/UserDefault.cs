namespace Entities.Concrete
{
    public class UserDefault
    {
        public Guid UserDefaultId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string CultereInfo { get; set; }
        public string Theme { get; set; }
    }
}

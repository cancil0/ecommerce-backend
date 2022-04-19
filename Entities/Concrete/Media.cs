using Entities.Abstract;

namespace Entities.Concrete
{
    public class Media : AuditEntity
    {
        public Guid MediaId { get; set; }

        public string Name { get; set; }
        public string Path { get; set; }
        public bool IsCoverPhoto { get; set; }
        public int Order { get; set; }

        public Product Product { get; set; }
    }
}

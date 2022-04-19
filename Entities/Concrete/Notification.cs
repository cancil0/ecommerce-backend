using Entities.Abstract;

namespace Entities.Concrete
{
    public class Notification : AuditEntity
    {
        public Guid NotificationId { get; set; }
        public string Type { get; set; }
        public string TypeSymbol { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}

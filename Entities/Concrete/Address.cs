using Entities.Abstract;

namespace Entities.Concrete
{
    public class Address : AuditEntity
    {
        public Guid AddressId { get; set; }
        public string AddressType { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string AddressInfo { get; set; }
        public string MobileNo { get; set; }
        public bool IsDefault { get; set; }

        public User User { get; set; }

        public List<Purchase> Purchases { get; set; }
        public List<Merchant> Merchants { get; set; }
    }
}

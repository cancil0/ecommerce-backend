using Entities.Abstract;
using Entities.EntityAttributes;

namespace Entities.Concrete
{
    public class Merchant : BaseEntity
    {
        public Guid MerchantId { get; set; }
        public string MerchantName { get; set; }
        public decimal MerchantPoint { get; set; }
        public long FeedbackCount { get; set; }

        [NotLoggableProperty]
        public long RegistrationNo { get; set; }

        public Address Address { get; set; }

        public List<ProductDetail> ProductDetails { get; set; }

    }
}

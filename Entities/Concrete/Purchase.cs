namespace Entities.Concrete
{
    public class Purchase
    {
        public Guid PurchaseId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public User User { get; set; }

        public Address Address { get; set; }

        public List<PurchasedProduct> PurchasedProducts { get; set; }
    }
}

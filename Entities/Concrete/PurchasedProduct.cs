namespace Entities.Concrete
{
    public class PurchasedProduct
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid PurchaseId { get; set; }
        public Purchase Purchase { get; set; }
    }
}

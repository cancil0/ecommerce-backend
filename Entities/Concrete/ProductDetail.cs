namespace Entities.Concrete
{
    public class ProductDetail
    {
        public Guid ProductDetailId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public string Detail { get; set; }
        public string Color { get; set; }
        public int? Size { get; set; }
        public long ClickCount { get; set; }
        public long PurchaseCount { get; set; }

        public Product Product { get; set; }
        public Merchant Merchant { get; set; }
    }
}

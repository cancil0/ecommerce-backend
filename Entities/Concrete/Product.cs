using Entities.Abstract;

namespace Entities.Concrete
{
    public class Product : BaseEntity
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public Category Category { get; set; }
        public List<Media> Medias { get; set; }
        public List<ProductDetail> ProductDetails { get; set; }

        public List<PurchasedProduct> PurchasedProducts { get; set; }
        public List<CartProduct> CartProducts { get; set; }
    }
}

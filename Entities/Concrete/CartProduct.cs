namespace Entities.Concrete
{
    public class CartProduct
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid CartId { get; set; }
        public Cart Cart { get; set; }
    }
}

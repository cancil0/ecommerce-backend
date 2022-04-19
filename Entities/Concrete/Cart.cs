namespace Entities.Concrete
{
    public class Cart
    {
        public Guid CartId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public List<CartProduct> CartProducts { get; set; }
    }
}

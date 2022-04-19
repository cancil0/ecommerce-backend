using Entities.Abstract;
using System.Text.Json.Serialization;

namespace Entities.Concrete
{
    public class User : BaseEntity
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string UserName { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public int BirthDate { get; set; }

        public string Email { get; set; }

        public string MobileNo { get; set; }

        public string Gender { get; set; }

        public Cart Cart { get; set; }

        public List<Address> Addresses { get; set; }

        public List<Purchase> Purchases { get; set; }

        public List<UserRole> UserRoles { get; set; }

    }
}

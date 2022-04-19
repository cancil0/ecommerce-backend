using System.ComponentModel;

namespace Entities.Enums
{
    public enum UserRoles
    {
        [Description("Admin"), Value("A")]
        Admin,

        [Description("Customer"), Value("C")]
        Customer,

        [Description("Merchant"), Value("M")]
        Merchant,
    }
}

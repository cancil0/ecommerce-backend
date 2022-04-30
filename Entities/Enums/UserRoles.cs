using System.ComponentModel;

namespace Entities.Enums
{
    public enum UserRoles
    {
        [Description("Admin"), Value("admin")]
        Admin,

        [Description("Customer"), Value("customer")]
        Customer,

        [Description("Merchant"), Value("merchant")]
        Merchant,

        [Description("Stuff"), Value("stuff")]
        Stuff,
    }
}

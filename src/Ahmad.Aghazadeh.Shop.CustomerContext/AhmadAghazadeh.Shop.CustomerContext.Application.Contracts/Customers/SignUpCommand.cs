
using AhmadAghazadeh.Framework.Core.Application;

namespace AhmadAghazadeh.Shop.CustomerContext.Application.Contracts.Customers
{
    public class SignUpCommand:Command
    {
        public string NationalCode { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

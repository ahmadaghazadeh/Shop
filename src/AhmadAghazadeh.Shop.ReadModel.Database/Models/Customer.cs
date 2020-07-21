using System;
using System.Collections.Generic;

namespace AhmadAghazadeh.Shop.ReadModel.Database.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Addresses = new HashSet<Address>();
        }

        public Guid Id { get; set; }
        public string NationalCode { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}

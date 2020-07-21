using System;
using System.Collections.Generic;

namespace AhmadAghazadeh.Shop.ReadModel.Database.Models
{
    public partial class Address
    {
        public Guid Id { get; set; }
        public string PostalCode { get; set; }
        public string AddressLine { get; set; }
        public int CityId { get; set; }
        public Guid CustomerId { get; set; }
        public string Telephone { get; set; }
        public string Coordinate { get; set; }

        public virtual Customer Customer { get; set; }
    }
}

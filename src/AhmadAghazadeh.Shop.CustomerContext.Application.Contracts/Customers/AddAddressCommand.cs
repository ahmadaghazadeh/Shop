using System;
using AhmadAghazadeh.Framework.Core.Application;

namespace AhmadAghazadeh.Shop.CustomerContext.Application.Contracts.Customers
{
    public class AddAddressCommand : Command
    {
        public string PostalCode { get;  set; }

        public string AddressLine { get;  set; }

        public int CityId { get;  set; }

        public Guid CustomerId { get;  set; }

        public string Telephone { get; set; }

        public string Coordinate { get; set; }
    }
}
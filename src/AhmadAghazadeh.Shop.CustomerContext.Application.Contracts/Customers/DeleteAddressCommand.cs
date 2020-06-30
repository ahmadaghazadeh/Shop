using System;
using AhmadAghazadeh.Framework.Core.Application;

namespace AhmadAghazadeh.Shop.CustomerContext.Application.Contracts.Customers
{
    public class DeleteAddressCommand : Command
    {
        public Guid CustomerId { get;  set; }

        public Guid AddressId { get; set; }

    }
}
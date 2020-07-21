using System;

namespace AhmadAghazadeh.Shop.ReadModel.Query.Facade.Contracts.Customer.DataContracts
{
   public class CustomerDto
    {
        public Guid Id { get; set; }
        public string NationalCode { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool HasAddress { get; set; }
    }
}

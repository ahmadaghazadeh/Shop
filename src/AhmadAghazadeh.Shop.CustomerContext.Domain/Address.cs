using System;
using AhmadAghazadeh.Framework.Domain;

namespace AhmadAghazadeh.Shop.CustomerContext.Domain
{
    public class Address : EntityBase
    {
        public Address(Guid customerId,string postalCode,string addressLine,int cityId)
        {
            CustomerId = customerId;
            CityId = cityId;
            SetAddressLine(addressLine);
            SetPostalCode(postalCode);
        }

       


        public string PostalCode { get; private set; }

        public string AddressLine { get; private set; }

        public int CityId { get; private set; }

        public Guid CustomerId { get; private set; }

        public string Telephone { get;  set; }

        public string Coordinate { get;  set; }
 

        private void SetPostalCode(string postalCode)
        {
            if (string.IsNullOrWhiteSpace(postalCode))
            {
                throw new Exceptions.PostalCodeRequiredException();
            }

            PostalCode = postalCode;
        }

        private void SetAddressLine(string addressLine)
        {
            if (string.IsNullOrWhiteSpace(addressLine))
            {
                throw new Exceptions.AddressLineRequiredException();
            }

            AddressLine = addressLine;
        }

    }
}

 
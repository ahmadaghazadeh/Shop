using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using AhmadAghazadeh.Framework.Domain;
using AhmadAghazadeh.Shop.CustomerContext.Domain.Customers.Exceptions;

namespace AhmadAghazadeh.Shop.CustomerContext.Domain.Customers
{
    public class Address:EntityBase
    {
        public string AddressLine { get;private set; }
        public string PostalCode { get;private set; }
        public Guid CustomerId { get;private set; }
        public int CityId { get;private set; }
        public string Telephone { get;private set; }

        protected Address(){}

        public Address(Guid customerId,string addressLine, string postalCode, int cityId)
        {
            CustomerId = customerId;
            SetAddressLine(addressLine);
            SetPostalCode(postalCode);
            SetCityId(cityId);
        }

        public Customer Customer { get; set; }

        private void SetCityId( int cityId)
        {
            if (cityId == 0)
            {
                throw  new CityIdRequiredException();
            }

            CityId = cityId;
        }

        private void SetPostalCode(string postalCode)
        {
            if (string.IsNullOrWhiteSpace(postalCode))
            {
                throw new PostalCodeRequiredException();
            }

            PostalCode = postalCode;

        }

        private void SetAddressLine(string addressLine)
        {
            if (string.IsNullOrWhiteSpace(addressLine))
            {
                throw new AddressLineRequiredException();
            }

            AddressLine = addressLine;
        }

        public void SetTelephone(string phoneNumber)
        {
            if (!Regex.IsMatch(phoneNumber, @"^(\+98|0)?9\d{9}$"))
            {
                throw new PhoneNumberInvalidException();
            }

            Telephone = phoneNumber;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using AhmadAghazadeh.Shop.CustomerContext.Domain.Customers;
using AhmadAghazadeh.Shop.CustomerContext.Domain.Customers.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AhmadAghazadeh.Shop.CustomerContext.Tests.Domain.Customers
{
    [TestClass]
    public class AddressTest
    {

        [TestMethod,TestCategory("AddressLine")]
        [ExpectedException(typeof(AddressLineRequiredException))]
        [DataRow(""),DataRow("  "),DataRow(null)]
        public void AddressLineIsNullOrWhiteSpace_ThrowException(string addressLine)
        {
             InitializeAddress(addressLine:addressLine);
        }


        [TestMethod, TestCategory("AddressLine")]
        public void ValidAddressLine_Retrieve()
        {
            var addressLine = "25 Khayaban Street, Tabriz, Iran";
            var address = InitializeAddress(addressLine: addressLine);
            Assert.AreEqual(addressLine,address.AddressLine);
        }


        [TestMethod, TestCategory("PostalCode")]
        [ExpectedException(typeof(PostalCodeRequiredException))]
        [DataRow(""), DataRow("  "), DataRow(null)]
        public void PostalCodeIsNullOrWhiteSpace_ThrowException(string postalCode)
        {
            InitializeAddress(postalCode: postalCode);
        }

        [TestMethod, TestCategory("PostalCode")]
        public void ValidPostCode_Retrieve()
        {
            var postalCode = "1234567890";
            var address = InitializeAddress(postalCode: postalCode);
            Assert.AreEqual(postalCode, address.PostalCode);
        }

        [TestMethod, TestCategory("CustomerId")]
        public void ValidCustomerId_Retrieve()
        {
            var customerId =new Guid();
            var address = InitializeAddress(customerId: customerId);
            Assert.AreEqual(customerId, address.CustomerId);
        }

        

        [TestMethod, TestCategory("CityId")]
        [ExpectedException(typeof(CityIdRequiredException))]
        public void CityIdIs0_ThrowException()
        {
            InitializeAddress(cityId:0);
        }

        [TestMethod, TestCategory("CityId")]
        public void ValidCityId_Retrieve()
        {
            var cityId = 1;
            var address = InitializeAddress(cityId: cityId);
            Assert.AreEqual(cityId, address.CityId);
        }

        [TestMethod, TestCategory("Telephone")]
        [ExpectedException(typeof(PhoneNumberInvalidException))]
        [DataRow("+98/9352185069"), DataRow("+98-9352185069")]
        public void PhoneNumberIsNotValid_ThrowException(string telephone)
        {
            InitializeAddress(telephone: telephone);
        }

        [TestMethod, TestCategory("Telephone")]
        public void ValidTelephone_Retrieve()
        {
            string telephone = "+989352185069";
            var address = InitializeAddress(telephone: telephone);
            Assert.AreEqual(telephone, address.Telephone);
        }


        private Address InitializeAddress(
            Guid customerId=new Guid(),
            string addressLine= "25 Khayaban Street, Tabriz, Iran",
            string postalCode = "123456",
            int cityId=1,
            string telephone = "+989352185069" )
        {
            var address= new Address(customerId, addressLine, postalCode, cityId);
            address.SetTelephone(telephone);
            return address;
        }
    }
}

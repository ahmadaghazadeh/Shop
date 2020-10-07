using System;
using AhmadAghazadeh.Framework.Core.Security;
using AhmadAghazadeh.Shop.CustomerContext.Domain.Customers;
using AhmadAghazadeh.Shop.CustomerContext.Domain.Customers.Exceptions;
using AhmadAghazadeh.Shop.CustomerContext.Domain.Customers.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AhmadAghazadeh.Shop.CustomerContext.Tests.Domain.Customers
{
    [TestClass]
    public class CustomerTest:INationalCodeDuplicationChecker,IHashProvider
    {
        private bool isNationalCodeDuplicate;

        [TestInitialize()]
        public void SetUp()
        {
            isNationalCodeDuplicate = false;
        }

        [TestMethod,TestCategory("FirstName")]
        [ExpectedException(typeof(FirstNameRequiredException))]
        [DataRow(""), DataRow("  "), DataRow(null)]
        public void FirstNameIsNullOrWhiteSpace_ThrowException(string firstName)
        {
              InitializeCustomer(firstName: firstName);
        }


        [TestMethod, TestCategory("FirstName")]
        public void ValidFirstName_Retrieve()
        {
            var firstName = "Ahmad";
            var customer = InitializeCustomer(firstName);
            Assert.AreEqual(firstName,customer.FirstName);
            
        }

        [TestMethod, TestCategory("LastName")]
        [ExpectedException(typeof(LastNameRequiredException))]
        [DataRow(""), DataRow("  "), DataRow(null)]
        public void LastNameIsNullOrWhiteSpace_ThrowException(string lastName)
        {
             InitializeCustomer(lastName: lastName);
        }



        [TestMethod, TestCategory("LastName")]
        public void ValidLastName_Retrieve()
        {
            var lastName = "Aghazadeh";
            var customer = InitializeCustomer( lastName: lastName);
            Assert.AreEqual(lastName, customer.LastName);

        }

        [TestMethod, TestCategory("NationalCode")]
        [ExpectedException(typeof(NationalCodeAllChartersIsDigitException))]
        public void NationalCodeAllCharacterIsDigit_ThrowException()
        {
             InitializeCustomer(  nationalCode:"123456789A");
        }

        [TestMethod, TestCategory("NationalCode")]
        [ExpectedException(typeof(NationalCodeLengthInvalidException))]

        public void NationalCodeIs10Length_ThrowException()
        {
              InitializeCustomer(nationalCode: "123456789");
        }

        [TestMethod, TestCategory("NationalCode")]
        [ExpectedException(typeof(NationalCodeRequiredException))]
        [DataRow(""), DataRow("  "), DataRow(null)]
        public void NationalCodeIsNullOrWhiteSpace_ThrowException(string nationalCode)
        {
            InitializeCustomer(nationalCode:nationalCode);
        }
 

        [TestMethod, TestCategory("NationalCode")]
        [ExpectedException(typeof(NationalCodeDuplicateException))]
        public void NationalCodeIsDuplicate_ThrowException()
        {
            isNationalCodeDuplicate = true;
            var customer = InitializeCustomer("Ahmad", "Aghazadeh", "1385976657");
        }

        [TestMethod, TestCategory("NationalCode")]
        public void ValidNationalCode_Retrieve()
        {
            var nationalCode = "1234567890";
            var customer = InitializeCustomer("Ahmad", "Aghazadeh", nationalCode);
            Assert.AreEqual(nationalCode,customer.NationalCode);
        }

        [TestMethod, TestCategory("Password")]
        [ExpectedException(typeof(PasswordRequiredException))]
        [DataRow(""), DataRow("  "), DataRow(null)]
        public void PasswordIsNullOrWhiteSpace_ThrowException(string password)
        {
             InitializeCustomer(password:password);
        }


        [TestMethod, TestCategory("Password")]
        [ExpectedException(typeof(PasswordLengthLessThanSixException))]
        public void PasswordIsLessThan6Length_ThrowException()
        {
              InitializeCustomer(password: "12345");
        }

        [TestMethod, TestCategory("Password")]
        public void ValidPasswordHash_Retrieve()
        {
            var password = "123456";
            var customer = InitializeCustomer("Ahmad", "Aghazadeh", "1234567890", password);
            Assert.AreEqual(password.GetHashCode().ToString(), customer.Password);
            
        }


        [TestMethod, TestCategory("Address")]
        [ExpectedException(typeof(AddressRequiredException))]
        public void AddressWhenAddIsNull_ThrowException()
        {
            var customer = InitializeCustomer("Ahmad", "Aghazadeh", "1234567890", "123456");
            customer.AddAddress(null);

        }

        [TestMethod, TestCategory("Score")]
        public void Add10ToScore_Score10Added()
        {
            var score = 10;
            var customer = InitializeCustomer();
            var beforeScore = customer.Score;
            customer.UpdateScore(score);

            Assert.AreEqual(score+ beforeScore, customer.Score);

        }

        [TestMethod, TestCategory("Address")]
        public void ValidNewAddressAdded_Retrieve()
        {
            var customer = InitializeCustomer("Ahmad", "Aghazadeh", "1234567890", "123456");
            var address=new Address(new Guid(), "Tabriz","1234567890",1);
            customer.AddAddress(address);
            Assert.IsTrue( customer.Addresses.Contains(address));

        }

        [TestMethod, TestCategory("Address")]
        public void ValidAddressRemove_NotFound()
        {
            var customer = InitializeCustomer("Ahmad", "Aghazadeh", "1234567890", "123456");
            var address = new Address(new Guid(), "Tabriz", "1234567890",1);
            customer.AddAddress(address);
            customer.DeleteAddress(address.Id);
            Assert.IsFalse(customer.Addresses.Contains(address));

        }

        [TestMethod,TestCategory("Email")]
        [ExpectedException(typeof(EmailRequiredException))]
        [DataRow(""), DataRow("  "), DataRow(null)]
        public void EmailIsNullOrWhiteSpace_ThrowException(string email)
        {
              InitializeCustomer(email: email);

        }

   



        [TestMethod, TestCategory("Email")]
        [ExpectedException(typeof(EmailInvalidFormatException))]
        [DataRow("@k"),DataRow("ahmad.aghazadeh"), DataRow("ahmad.aghazadeh@")]
        [DataRow("@gmail.com"), DataRow("ahmad.aghazadeh.com")]
        public void EmailIsNotValidFormat_ThrowException(string email)
        {
             InitializeCustomer( email: email);
        
        }

        [TestMethod, TestCategory("Email")]
        public void ValidEmail_Retrieve()
        {
            var email = "Ahmad.Aghazadeh.a@gmail.com";
            var customer = InitializeCustomer(email: email
                );
            Assert.AreEqual(email,customer.Email);

        }



        public bool IsDuplicate(string nationalCode)
        {
            return isNationalCodeDuplicate;
        }

        private Customer InitializeCustomer(
            string firstName = "Ahmad",
            string lastName="Aghazadeh",
            string nationalCode= "1385976654",
            string password="123654",
            string email="Ahmad.Aghazadeh.a@gmail.com")
        {
           
            return new Customer(this,this,firstName,lastName,nationalCode,password, email);
        }


        public string Hash(string textPlan, string saltedValue)
        {
            return  (textPlan).GetHashCode().ToString();
        }
    }

     
}

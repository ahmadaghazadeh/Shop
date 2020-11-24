using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AhmadAghazadeh.Framework.Core.Domain;
using AhmadAghazadeh.Framework.Core.Security;
using AhmadAghazadeh.Framework.Domain;
using AhmadAghazadeh.Shop.CustomerContext.Domain.Customers.Exceptions;
using AhmadAghazadeh.Shop.CustomerContext.Domain.Customers.Services;

namespace AhmadAghazadeh.Shop.CustomerContext.Domain.Customers
{
    public class Customer:EntityBase, IAggregateRoot
    {
        private readonly INationalCodeDuplicationChecker nationalCodeDuplicationChecker;
        private readonly IHashProvider hashProvider;
        public string FirstName { get;private set; }
      
        public string LastName { get;private set; }
        public string NationalCode { get;private set; }
        public string Password { get;private set; }
        public string Email { get; private set; }
        public int Score { get; private set; }

        public ICollection<Address> Addresses { get; set; }=new HashSet<Address>();

        protected Customer() { }
        public Customer(
            INationalCodeDuplicationChecker nationalCodeDuplicationChecker, 
            IHashProvider hashProvider,
            string firstName,
            string lastName,
            string nationalCode, string password, string email)
        {
            this.nationalCodeDuplicationChecker = nationalCodeDuplicationChecker;
            this.hashProvider = hashProvider;
           

            SetFirstNme(firstName);
            SetLastName(lastName);
            SetNationalCode(nationalCode);
            SetPassword(password);
            SetEmail(email);
        }

        private void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new EmailRequiredException();
            }
            if (!Regex.IsMatch(email, @"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"))
            {
                throw new EmailInvalidFormatException();
            }

            this.Email = email;
        }

        private void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new PasswordRequiredException();
            }
            if (password.Length<6)
            {
                throw new PasswordLengthLessThanSixException();
            }

            this.Password = hashProvider.Hash(password,Id.ToString());

        }

        private void SetNationalCode(string nationalCode)
        {

            if (string.IsNullOrWhiteSpace(nationalCode))
            {
                throw new NationalCodeRequiredException();
            }
            if (nationalCode.Length != 10)
            {
                throw new NationalCodeLengthInvalidException();
            }
            if (!nationalCode.All(char.IsDigit))
            {
                throw new NationalCodeAllChartersIsDigitException();
            }
            if (nationalCodeDuplicationChecker.IsDuplicate(nationalCode))
            {
                throw new NationalCodeDuplicateException();
            }

            NationalCode = nationalCode;
        }

        private void SetLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new LastNameRequiredException();
            }

            LastName = lastName;
        }

        private void SetFirstNme(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new FirstNameRequiredException();
            }

            FirstName = firstName;

        }

        public void AddAddress(Address address)
        {
            if (address == null)
            {
                throw new AddressRequiredException();
            }
            Addresses.Add(address);
        }

        public void DeleteAddress(Guid id)
        {
            var forDelete = Addresses.FirstOrDefault(a => a.Id == id);
            Addresses.Remove(forDelete);
        }

        public void UpdateScore(in int score)
        {
            Score += score;
        }
    }
}

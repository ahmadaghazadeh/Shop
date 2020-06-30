using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AhmadAghazadeh.Framework.Core.Security;
using AhmadAghazadeh.Framework.Domain;
using AhmadAghazadeh.Shop.CustomerContext.Domain.Services;

namespace AhmadAghazadeh.Shop.CustomerContext.Domain
{
    public class Customer: EntityBase
    {
        private readonly INationalCodeDuplicationChecker nationalCodeDuplicationChecker;
        private readonly IHashProvider hashProvider;

        public string NationalCode { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public ICollection<Address> Addresses { get; private set; }

        public void AddAddress(Address address)
        {
            Addresses.Add(address);
        }

        public void DeleteAddress(Guid addressId)
        {
            var forDelete = Addresses
                .FirstOrDefault(a => a.Id == addressId);
            Addresses.Remove(forDelete);
        }
        public Customer(
            INationalCodeDuplicationChecker nationalCodeDuplicationChecker,
            IHashProvider hashProvider,
            string nationalCode,
            string email,
            string password,
            string firstName,
            string lastName)
        {
            this.nationalCodeDuplicationChecker = nationalCodeDuplicationChecker;
            this.hashProvider = hashProvider;
            SetNationalCode(nationalCode);
            SetEmail(email);
            SetFirstName(firstName);
            SetLastName(lastName);
            SetPassword(password);
        }

       


        private void SetNationalCode(string nationalCode)
        {
            if (string.IsNullOrWhiteSpace(nationalCode))
            {
                throw new Exceptions.NationalCodeRequiredException();
            }

            if (nationalCode.Length!=10)
            {
                throw new Exceptions.NationalCodeLengthInvalidException();
            }

            if (nationalCode.All(char.IsDigit))
            {
                throw new Exceptions.NationalCodeAllChartersIsDigitException();
            }

            if (nationalCodeDuplicationChecker.IsDuplicated(nationalCode))
            {
                throw new Exceptions.NationalCodeDuplicateException();
            }

            NationalCode = nationalCode;
        }

        private void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exceptions.EmailRequiredException();
            }

            if (Regex.IsMatch(email, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                                     @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$"))
            {
                throw new Exceptions.EmailRequiredException();
            }
            Email = email;
        }


        private void SetLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new Exceptions.LastNameRequiredException();
            }

            LastName = lastName;
        }

        private void SetFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new Exceptions.FirstNameRequiredException();
            }

            FirstName = firstName;
        }

        private void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exceptions.PasswordRequiredException();
            }

            if (password.Length>6)
            {
                throw new Exceptions.PasswordLengthUpperThanSixException();
            }

            Password = hashProvider.Hash(password,Id.ToString());
        }

    }
}
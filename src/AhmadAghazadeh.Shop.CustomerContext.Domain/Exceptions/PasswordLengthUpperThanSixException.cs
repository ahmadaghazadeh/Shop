using AhmadAghazadeh.Framework.Domain;
using AhmadAghazadeh.Shop.CustomerContext.Resources;

namespace AhmadAghazadeh.Shop.CustomerContext.Domain.Exceptions
{
    public class PasswordLengthUpperThanSixException : DomainException
    {
        public override string Message => ExceptionResource.PasswordLengthUpperThanSixException;
    }
}
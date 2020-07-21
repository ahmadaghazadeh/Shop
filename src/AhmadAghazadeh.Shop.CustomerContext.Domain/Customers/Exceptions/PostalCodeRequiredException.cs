using AhmadAghazadeh.Framework.Domain;
using AhmadAghazadeh.Shop.CustomerContext.Resources;

namespace AhmadAghazadeh.Shop.CustomerContext.Domain.Customers.Exceptions
{
    public class PostalCodeRequiredException : DomainException
    {
        public override string Message => ExceptionResource.PostalCodeRequiredException;
    }
}
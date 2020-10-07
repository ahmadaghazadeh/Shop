using AhmadAghazadeh.Framework.Domain;
using AhmadAghazadeh.Shop.CustomerContext.Resources;

namespace AhmadAghazadeh.Shop.CustomerContext.Domain.Customers.Exceptions
{
    public class AddressLineRequiredException : DomainException
    {
        public override string Message => ExceptionResource.AddressLineRequiredException;
    }
}
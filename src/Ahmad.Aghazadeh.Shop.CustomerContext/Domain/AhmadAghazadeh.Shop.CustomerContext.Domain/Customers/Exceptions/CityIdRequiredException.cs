using AhmadAghazadeh.Framework.Domain;
using AhmadAghazadeh.Shop.CustomerContext.Resources;

namespace AhmadAghazadeh.Shop.CustomerContext.Domain.Customers.Exceptions
{
    public class CityIdRequiredException : DomainException
    {
        public override string Message => ExceptionResource.CityIdRequiredException;
    }
}
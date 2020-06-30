using AhmadAghazadeh.Framework.Domain;
using AhmadAghazadeh.Shop.CustomerContext.Resources;

namespace AhmadAghazadeh.Shop.CustomerContext.Domain.Exceptions
{
    public class FirstNameRequiredException : DomainException
    {
        public override string Message => ExceptionResource.FirstNameRequiredException;
    }
}
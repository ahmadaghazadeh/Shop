using AhmadAghazadeh.Framework.Domain;
using AhmadAghazadeh.Shop.OrderContext.Resources;

namespace AhmadAghazadeh.Shop.OrderContext.Domain.Orders.Exceptions
{
    public class PriceIsNotZeroException : DomainException
    {
        public override string Message => ExceptionResource.PriceIsNotZeroException;
    }
}
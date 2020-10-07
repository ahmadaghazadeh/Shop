using AhmadAghazadeh.Framework.Domain;
using AhmadAghazadeh.Shop.OrderContext.Resources;

namespace AhmadAghazadeh.Shop.OrderContext.Domain.Orders.Exceptions
{
    public class QuantityIsNotZeroException : DomainException
    {
        public override string Message => ExceptionResource.QuantityIsNotZeroException;
    }
}
using System;
using AhmadAghazadeh.Framework.Domain;
using AhmadAghazadeh.Shop.OrderContext.Resources;

namespace AhmadAghazadeh.Shop.OrderContext.Domain.Orders.Exceptions
{
    public class CartRequiredException : DomainException
    {
        public override string Message => ExceptionResource.CartRequiredException;
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using AhmadAghazadeh.Framework.Domain;
using AhmadAghazadeh.Shop.CustomerContext.Resources;

namespace AhmadAghazadeh.Shop.CustomerContext.Domain.Customers.Exceptions
{
    public class LastNameRequiredException : DomainException
    {
        public override string Message => ExceptionResource.LastNameRequiredException;
    }
}

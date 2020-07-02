using System;
using System.Collections.Generic;
using System.Text;
using AhmadAghazadeh.Framework.Domain;

namespace AhmadAghazadeh.Shop.CustomerContext.Domain.Services
{
    public interface INationalCodeDuplicationChecker: IDomainService
    {
        public bool IsDuplicated(string nationalCode);
    }
}

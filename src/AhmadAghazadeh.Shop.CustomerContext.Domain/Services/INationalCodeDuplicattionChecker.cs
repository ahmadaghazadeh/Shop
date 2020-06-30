using System;
using System.Collections.Generic;
using System.Text;

namespace AhmadAghazadeh.Shop.CustomerContext.Domain.Services
{
    public interface INationalCodeDuplicationChecker
    {
        public bool IsDuplicated(string nationalCode);
    }
}

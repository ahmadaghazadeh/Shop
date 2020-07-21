using AhmadAghazadeh.Framework.Core.Domain;
using AhmadAghazadeh.Framework.Domain;

namespace AhmadAghazadeh.Shop.CustomerContext.Domain.Customers.Services
{
    public interface INationalCodeDuplicationChecker: IDomainService
    {
        public bool IsDuplicated(string nationalCode);
    }
}

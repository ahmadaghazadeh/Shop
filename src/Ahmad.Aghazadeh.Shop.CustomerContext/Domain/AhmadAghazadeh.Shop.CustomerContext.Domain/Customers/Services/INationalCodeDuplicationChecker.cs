using AhmadAghazadeh.Framework.Core.Domain;

namespace AhmadAghazadeh.Shop.CustomerContext.Domain.Customers.Services
{
    public interface INationalCodeDuplicationChecker:IDomainService
    {
        bool IsDuplicate(string nationalCode);
    }
}
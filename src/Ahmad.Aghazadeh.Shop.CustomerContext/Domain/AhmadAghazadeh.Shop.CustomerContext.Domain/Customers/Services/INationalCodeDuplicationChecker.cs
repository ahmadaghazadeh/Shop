namespace AhmadAghazadeh.Shop.CustomerContext.Domain.Customers.Services
{
    public interface INationalCodeDuplicationChecker
    {
        bool IsDuplicate(string nationalCode);
    }
}

using AhmadAghazadeh.Shop.CustomerContext.Domain.Customers.Services;

namespace AhmadAghazadeh.Shop.CustomerContext.Domain.Services.Customers
{
    public class NationalCodeDuplicationChecker:INationalCodeDuplicationChecker
    {
        private readonly ICustomerRepository customerRepository;
        public NationalCodeDuplicationChecker(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public bool IsDuplicate(string nationalCode)
        {
          return  customerRepository.Contains(c=>c.NationalCode==nationalCode);
        }

        
    }
}

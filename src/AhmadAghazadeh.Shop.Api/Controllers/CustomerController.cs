using AhmadAghazadeh.Shop.CustomerContext.Application.Contracts.Customers;
using AhmadAghazadeh.Shop.CustomerContext.Facade.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AhmadAghazadeh.Shop.Api.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerCommandFacade customerCommandFacade;
        //private readonly ICustomerQueryFacade customerQueryFacade;

        public CustomerController(ICustomerCommandFacade customerCommandFacade)//, ICustomerQueryFacade customerQueryFacade)
        {
            this.customerCommandFacade = customerCommandFacade;
            //this.customerQueryFacade = customerQueryFacade;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void SignUp(SignUpCommand command)
        {
            customerCommandFacade.SignUp(command);
        }

        [HttpPut]
        public void AddAddress(AddAddressCommand command)
        {
            customerCommandFacade.AddAddress(command);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete ]
        public void DeleteAddress(DeleteAddressCommand command)
        {
            customerCommandFacade.DeleteAddress(command);
        }

    }
}

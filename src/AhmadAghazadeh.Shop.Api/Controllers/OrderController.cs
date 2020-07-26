using AhmadAghazadeh.Shop.OrderContext.Application.Contracts.Orders;
using AhmadAghazadeh.Shop.OrderContext.Facade.Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AhmadAghazadeh.Shop.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderCommandFacade commandFacade;

        public OrderController(IOrderCommandFacade commandFacade)
        {
            this.commandFacade = commandFacade;
        }

        [HttpPost]
        public void CreateOrder(CreateOrderCommand command)
        {
            commandFacade.CreateOrder(command);
        }

         
    }
}

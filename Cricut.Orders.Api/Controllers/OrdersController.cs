using Cricut.Orders.Api.Mappings;
using Cricut.Orders.Api.ViewModels;
using Cricut.Orders.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Cricut.Orders.Api.Controllers
{
    [Route("v1/orders")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly IOrderDomain _orderDomain;

        public OrdersController(IOrderDomain orderDomain)
        {
            _orderDomain = orderDomain;
        }

        [HttpPost]
        public async Task<ActionResult<OrderViewModel>> CreateNewOrderAsync([FromBody] NewOrderViewModel newOrderVM)
        {
            var newOrder = newOrderVM.ToDomainModel();
            var savedOrder = await _orderDomain.CreateNewOrderAsync(newOrder);
            return Ok(savedOrder.ToViewModel());
        }

        // Aaron GenAI Note: i used chatGPT to remember whether i needed a separate class, or if i could just add the new 
        // endpoint to this class. With chatGPT i confirmed i can add it here as an HttpGet method. 
        //
        // Here's the code i got from chatGPT, and then stopped using genAI for this stage. I also disabled CoPilot code completion
        //
        /** 
            [HttpGet("{id}")]
            public async Task<ActionResult<OrderViewModel>> GetOrderByIdAsync(Guid id)
            {
            var order = await _orderDomain.GetOrderByIdAsync(id);
            if (order == null)
            return NotFound();

            return Ok(order.ToViewModel());
            }

            }
            }
        **/
        [HttpGet("{custId}")]
        public async Task<ActionResult<OrderViewModel>> GetOrdersByCustomerID(int custId)
        {
            var orders = await _orderDomain.GetOrdersByCustomerId(custId);
            return null;
        }
    }
}
        
using Cricut.Orders.Domain.Models;
using System.Diagnostics;

namespace Cricut.Orders.Domain
{
    public interface IOrderDomain
    {
        Task<Order> CreateNewOrderAsync(Order order);
        Task<IEnumerable<Order>> GetOrdersByCustomerId(int custID);
    }

    public class OrderDomain : IOrderDomain
    {
        private readonly IOrderStore _orderStore;

        public OrderDomain(IOrderStore orderStore)
        {
            _orderStore = orderStore;
        }

        public async Task<Order> CreateNewOrderAsync(Order order)
        {
            var updatedOrder = await _orderStore.SaveOrderAsync(order);
            return updatedOrder;
        }

        //GenAI Note: Used ChatGTP to suggest the correct return type. Didn't use Task<ActionResult<IEnum... to avoid further imports for purpose of simplicity in the challenge.
        public async Task<IEnumerable<Order>> GetOrdersByCustomerId(int custID)
        {
            Debug.Print("tsup yo");
            return null;
        }
    }
}

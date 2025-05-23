using Cricut.Orders.Domain.Models;
using System.Diagnostics;

namespace Cricut.Orders.Domain
{
    public interface IOrderDomain
    {
        Task<Order> CreateNewOrderAsync(Order order);
        Task<Order[]> GetOrdersByCustomerId(int custID);
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

        public async Task<Order[]> GetOrdersByCustomerId(int custID)
        {
            var orders = await _orderStore.GetAllOrdersForCustomerAsync(custID);

            return orders;
        }
    }
}

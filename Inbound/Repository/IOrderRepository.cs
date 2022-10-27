using Inbound.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inbound.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderDto>> GetOrders();
        Task<OrderDto> GetOrderById(int orderId);
        Task<OrderDto> CreateUpdateOrder(OrderDto orderDto);
        Task<bool> DeleteOrder(int orderId);
    }
}

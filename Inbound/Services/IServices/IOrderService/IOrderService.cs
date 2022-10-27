using Inbound.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inbound.Services.IServices.IOrderService
{
   public interface IOrderService : IBaseService
    {
        Task<T> GetAllOrdersAsync<T>();
        Task<T> GetOrderByIdAsync<T>(int id);
        Task<T> CreateOrderAsync<T>(OrderDto orderDto);
        Task<T> UpdateOrderAsync<T>(OrderDto orderDto);
        Task<T> DeleteOrderAsync<T>(int id);
    }
}

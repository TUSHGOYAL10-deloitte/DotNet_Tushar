using AutoMapper;
using Inbound.DbContexts;
using Inbound.Models;
using Inbound.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inbound.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;
        public OrderRepository(ApplicationDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<OrderDto> CreateUpdateOrder(OrderDto orderDto)
        {
            Order order = _mapper.Map<OrderDto, Order>(orderDto);
            if(order.OrderId>0)
            {
                _db.Orders.Update(order);
            }
            else
            {
                _db.Orders.Add(order);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Order, OrderDto>(order);
        }

        public async Task<bool> DeleteOrder(int orderId)
        {
            try
            {

                Order order = await _db.Orders.FirstOrDefaultAsync(u => u.OrderId == orderId);
                if(order==null)
                {
                    return false;
                }
                _db.Orders.Remove(order);
                await _db.SaveChangesAsync();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<OrderDto> GetOrderById(int orderId)
        {
            //throw new NotImplementedException();
            Order order = await _db.Orders.Where(x => x.OrderId == orderId).FirstOrDefaultAsync();
            return _mapper.Map<OrderDto>(order);

        }
        public async Task<IEnumerable<OrderDto>> GetOrders()
        {
            List<Order> orderList = await _db.Orders.ToListAsync();
            return _mapper.Map<List<OrderDto>>(orderList);
        }

       
    }
}

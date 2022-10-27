using Inbound.Models.Dto;
using Inbound.Services.IServices.IOrderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Inbound.Services
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly IHttpClientFactory _clientFactory;
        public OrderService(IHttpClientFactory clientFactory): base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> CreateOrderAsync<T>(OrderDto orderDto)
        {
            return await this.SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = orderDto,
                Url = SD.OrderAPIBase + "/api/orders",
                AccessToken = ""
            });
        }
        public async Task<T> DeleteOrderAsync<T>(int id )
        {
            return await this.SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                
                Url = SD.OrderAPIBase + "/api/orders"+ id,
                AccessToken = ""
            });
        }

      

        public async Task<T> GetAllOrdersAsync<T>()
        {
            return await this.SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = SD.ApiType.GET,

                Url = SD.OrderAPIBase + "/api/orders" ,
                AccessToken = ""
            });
        }

        public async Task<T> GetOrderByIdAsync<T>(int id)
        {
            return await this.SendAsync<T>(new Models.ApiRequest()
            {
                ApiType = SD.ApiType.GET,

                Url = SD.OrderAPIBase + "/api/orders"+ id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateOrderAsync<T>(OrderDto orderDto)
        {
            return await this.SendAsync<T>(new Models.ApiRequest() 
            { ApiType = SD.ApiType.PUT,
            Data= orderDto,
                Url = SD.OrderAPIBase + "/api/orders",
                AccessToken = "" });
        }
    }
}

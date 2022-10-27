using AutoMapper;
using Inbound.Models;
using Inbound.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inbound
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                 config.CreateMap<OrderDto, Order>();
                 config.CreateMap<Order, OrderDto>();


             });
            return mappingConfig;
        }
    }
}

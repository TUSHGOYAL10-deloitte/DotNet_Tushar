using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SystemManagement.Models;
using SystemManagement.Models.Dto;

namespace SystemManagement
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
              {
                  
                  config.CreateMap<Product, ProductDto>();
                  config.CreateMap<Node, NodeDto>();
                  config.CreateMap<Lpn, LpnDto>();
                  config.CreateMap<Pallet, PalletDto>();
                  config.CreateMap<WareHouse, WareHouseDto>();

              });

            return mappingConfig;
        }
    }
}

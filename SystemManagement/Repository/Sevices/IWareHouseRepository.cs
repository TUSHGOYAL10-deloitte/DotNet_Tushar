using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemManagement.Models.Dto;

namespace SystemManagement.Repository.Sevices
{
    public interface IWareHouseRepository
    {
        Task<IEnumerable<WareHouseDto>> GetWareHouses();

        Task<WareHouseDto> GetWareHouseById(int WareHouseId);


        Task<WareHouseDto> CreateUpdateWareHouse(WareHouseDto wareHouseDto);

        Task<bool> DeleteWareHouse(int WareHouseId);

    }
}

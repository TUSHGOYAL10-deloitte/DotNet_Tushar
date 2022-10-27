using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemManagement.Database;
using SystemManagement.Models;
using SystemManagement.Models.Dto;
using SystemManagement.Repository.Sevices;

namespace SystemManagement.Repository
{
    public class WareHouseRepository : IWareHouseRepository
    {


        private readonly ApiDbContext _dbcontext;
        private IMapper _mapper;

        public WareHouseRepository(ApiDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;

        }

        public async Task<WareHouseDto> CreateUpdateWareHouse(WareHouseDto wareHouseDto)
        {
            WareHouse wareHouse = _mapper.Map<WareHouseDto, WareHouse>(wareHouseDto);
            if (wareHouse.WareHouseId > 0)
            {
                _dbcontext.WareHouses.Update(wareHouse);

            }
            else
            {
                _dbcontext.WareHouses.Add(wareHouse);
            }
            await _dbcontext.SaveChangesAsync();
            return _mapper.Map<WareHouse, WareHouseDto>(wareHouse);
        }

       

        public async Task<bool> DeleteWareHouse(int WareHouseId)
        {
            try
            {
                WareHouse wareHouse = await _dbcontext.WareHouses.FirstOrDefaultAsync(u => u.WareHouseId == WareHouseId);
                if (wareHouse == null)
                {
                    return false;
                }
                _dbcontext.Remove(wareHouse);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

       

        public async Task<WareHouseDto> GetWareHouseById(int WareHouseId)
        {
            WareHouse wareHouse = await _dbcontext.WareHouses.Where(x => x.WareHouseId == WareHouseId).FirstOrDefaultAsync();
            return _mapper.Map<WareHouseDto>(wareHouse);
        }

        public async Task<IEnumerable<WareHouseDto>> GetWareHouses()
        {
            List<WareHouse> wareHouseList = await _dbcontext.WareHouses.ToListAsync();
            return _mapper.Map<List<WareHouseDto>>(wareHouseList);
        }
    }
}

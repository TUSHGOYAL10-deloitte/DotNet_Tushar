using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemManagement.Database;
using SystemManagement.Models.Dto;
using SystemManagement.Repository.Sevices;

namespace SystemManagement.Repository
{
    public class PalletRepository : IPalletRepository
    {
        private readonly ApiDbContext _dbcontext;
        private IMapper _mapper;

        public PalletRepository(ApiDbContext dbContext, IMapper mapper)
        {

            _dbcontext = dbContext;
            _mapper = mapper;

        }

        public async Task<PalletDto> CreateUpdatePallet(PalletDto palletDto)
        {
            Pallet pallet = _mapper.Map<PalletDto, Pallet>(palletDto);

            if (pallet.PalletId > 0)
            {
                _dbcontext.Pallets.Update(pallet);

            }
            else
            {
                _dbcontext.Pallets.Add(pallet);
            }

            await _dbcontext.SaveChangesAsync();
            return _mapper.Map<Pallet,PalletDto>(pallet);

        }


        async Task<bool> IPalletRepository.DeletePallet(int palletID)
        {
            try
            {
                Pallet pallet = await _dbcontext.Pallets.FirstOrDefaultAsync(u => u.PalletId == palletID);
                if (pallet == null)
                {
                    return false;
                }
                _dbcontext.Remove(pallet);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

       

        async Task<PalletDto> IPalletRepository.GetPalletById(int palletId)
        {
            Pallet pallet = await _dbcontext.Pallets.Where(x => x.PalletId == palletId).FirstOrDefaultAsync();
            return _mapper.Map<PalletDto>(pallet);
        }

        

        async Task<IEnumerable<PalletDto>> IPalletRepository.GetPallets()
        {
            List<Pallet> palletList = await _dbcontext.Pallets.ToListAsync();
            return _mapper.Map<List<PalletDto>>(palletList);
        }
    }
}

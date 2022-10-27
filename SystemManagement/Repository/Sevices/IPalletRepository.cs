using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemManagement.Models.Dto;

namespace SystemManagement.Repository.Sevices
{
    public interface IPalletRepository
    {
        Task<IEnumerable<PalletDto>> GetPallets();

        Task<PalletDto> GetPalletById(int palletId);


        Task<PalletDto> CreateUpdatePallet(PalletDto palletDto);

        Task<bool> DeletePallet(int palletID);


    }

}

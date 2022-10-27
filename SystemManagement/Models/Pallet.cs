using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SystemManagement.Models.Dto
{
    public class Pallet
    {

        [Key]
        public int PalletId { get; set; }

        

        public string PalletType { get; set; }

        public string Location { get; set; }

        public int LpnId { get; set; }

        public Lpn  Lpn { get; set; }

        



    }
}

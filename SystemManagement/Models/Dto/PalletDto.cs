using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SystemManagement.Models.Dto
{
    public class PalletDto
    {
        [Key]
        public int PalletId { get; set; }

        public int LpnId { get; set; }

        public string PalletType { get; set; }

        public string Location { get; set; }

        public LpnDto Lpndto { get; set; }

    }
}

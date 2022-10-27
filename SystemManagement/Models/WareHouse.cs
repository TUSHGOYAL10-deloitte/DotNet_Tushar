using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SystemManagement.Models
{
    public class WareHouse
    {
        [Key]
        public int  WareHouseId { get; set; }

        public string Name { get; set; }

        public int ProductId { get; set; }

        public int NodeId { get; set; }

        public Node Node { get; set; }

        public Product product { get; set; }


    }
}

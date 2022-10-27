using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inbound.Models.Dto
{
    public class OrderDto
    {
        
        public int OrderId { get; set; }
        
        public string status { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }

        public string description { get; set; }
    }
}

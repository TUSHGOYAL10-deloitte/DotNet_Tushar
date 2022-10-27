using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemManagement.Models.Dto;

namespace SystemManagement.Models.Dto
{
    public class ProductDto
    {
        public int ProuctId { get; set; }

        public string ProductType { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

       
    }
}

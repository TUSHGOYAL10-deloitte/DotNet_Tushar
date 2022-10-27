using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SystemManagement.Models
{
    public class Product
    {

        [Key]
        public int  ProductId { get; set; }
        public string ProductType { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

    }
}

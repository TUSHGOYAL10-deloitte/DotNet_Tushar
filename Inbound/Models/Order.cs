using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Inbound.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public string status { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }

        public string description { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SystemManagement.Models
{
    public class Node
    {
        [Key]
        public int NodeId { get; set; }
        public string Name { get; set; }
    }
}

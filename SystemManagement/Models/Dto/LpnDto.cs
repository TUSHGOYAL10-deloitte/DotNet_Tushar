using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SystemManagement.Models
{
    public class LpnDto
    {
        [Key]
        public int Id { get; set; }

        public int NodeId { get; set; }

        public NodeDto nodeDto { get; set; }

    }
}

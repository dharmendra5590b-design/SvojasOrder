using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SvojasOrder.Models
{
    public class OrderReworkDtlDto
    {
        public int? Order_ID { get; set; }
        public int? SrNo { get; set; }
        public string? Specification { get; set; }
        public IFormFile? CADImage { get; set; }
        public int? User_ID { get; set; }
        public string? Mode { get; set; } = "A";
    }
}

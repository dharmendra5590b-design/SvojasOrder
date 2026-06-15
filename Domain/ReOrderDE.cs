using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ReOrderDE
    {
        public int? Order_ID { get; set; }
        public int? Customer_ID { get; set; }
        public string? Quantity { get; set; }
        public DateTime? Delivery_Date { get; set; }
        public string? Mode { get; set; } = "A";

    }
}

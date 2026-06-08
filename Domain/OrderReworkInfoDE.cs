using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OrderReworkInfoDE
    {
        public int Order_ID { get; set; }
        public string Order_Number { get; set; }
        public DateTime? Order_Date { get; set; }
        public string Customer_Name { get; set; }
        public string Order_Type { get; set; }
        public string Design { get; set; }
        public string? Quantity { get; set; }
        public DateTime? Delivery_Date { get; set; }

    }
}

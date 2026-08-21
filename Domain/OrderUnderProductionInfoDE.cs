using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OrderUnderProductionInfoDE
    {
        public int Order_ID { get; set; }
        public string Customer_Name { get; set; }
        public string Order_Number { get; set; }
        public DateTime? Order_Date { get; set; }
        public string Order_Type { get; set; }
        public string Design { get; set; }
        public string? Quantity { get; set; }
        public DateTime? Delivery_Date { get; set; }
        public DateTime? Committed_DT { get; set; }
        public string Designer_Name { get; set; }
        public DateTime? Designer_Assgined_DT { get; set; }
        public bool? Is_High_Priority { get; set; }
        public DateTime? Design_Upload_DT { get; set; }
        public DateTime? Design_Approved_DT { get; set; }
        public DateTime? Order_Confirmed_DT { get; set; }
        public DateTime? Production_Assigned_DT { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OrderDetailsGridDE
    {
        public int Order_ID { get; set; }
        public string Order_Number { get; set; }
        public string Order_Date { get; set; }
        public string Order_Type { get; set; }
        public int Design_ID { get; set; }
        public string Design { get; set; }
        public int Karat_ID { get; set; }
        public string Delivery_Date { get; set; }

        public string Is_Assigned_Designer { get; set; }
        public string Designer_Assgined_DT { get; set; }

        public string Is_Design_Approved { get; set; }
        public string Design_Approved_DT { get; set; }

        public string Is_Order_Confirmed { get; set; }
        public string Order_Confirmed_DT { get; set; }

        public string Is_Assigned_Production { get; set; }
        public string Production_Assigned_DT { get; set; }

        public string Is_OrderCompleted { get; set; }
        public string Order_Completed_DT { get; set; }

    }
}

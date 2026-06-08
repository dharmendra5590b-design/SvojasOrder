using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OrderSearchDE
    {
        public int? order_ID { get; set; }

        public DateTime? order_FromDT { get; set; }

        public DateTime? order_ToDT { get; set; }

        public int? design_ID { get; set; }

        public int? customer_ID { get; set; }
        public string mode { get; set; }
    }
}

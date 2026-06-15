using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OrderCancelRequestDE
    {
        public int Order_ID { get; set; }
        public int User_ID { get; set; }
        public int Cancel_Reason { get; set; }
        public int Cancelation_Charge { get; set; }

    }
}

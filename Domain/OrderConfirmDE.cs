using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OrderConfirmDE
    {
        public int Order_ID { get; set; }
        public string Action_Type { get; set; }   // CONFIRM | REWORK
        public string Rework_Specification { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderDesignRequest
    {
        public long? Order_ID { get; set; }

        public int? Designer_ID { get; set; }

        public string? Admin_Specification { get; set; }

        public bool? Is_High_Priority { get; set; }

        public DateTime? Design_Expected_DT { get; set; }
    }
}

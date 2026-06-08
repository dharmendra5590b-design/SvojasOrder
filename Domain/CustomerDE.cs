using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CustomerDE
    {
        public int Customer_ID { get; set; }

        public string Customer_Name { get; set; }

        public string Customer_Code { get; set; }

        public string Company_Name { get; set; }

        public string Mobile_Number { get; set; }

        public decimal Gold_OpeningBalance { get; set; }

        public decimal Amount_OpeningBalance { get; set; }

        public string Mode { get; set; } = "A";
        public string From_Date { get; set; }
        public string To_Date { get; set; }
    }
}

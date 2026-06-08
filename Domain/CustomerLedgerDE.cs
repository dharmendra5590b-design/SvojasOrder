using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain
{
    public class CustomerLedgerDE
    {
        public int Customer_ID { get; set; }
        public string  Trans_Date {get;set;}
        public string Voucher { get; set;}
        public string Particular { get; set; }
        public string GoldOut { get; set; }
        public string GoldIn { get; set;}
        public string AmountOut { get; set;}
        public string AmountIn { get; set;}
        public string Mode { get; set; }
    }

    public class CustomerLedgerInfoDE
    {
    public int Customer_ID { get; set; }
    public string Customer_Name { get; set; }
    public string Form_Date { get; set; }
    public string To_Date { get; set; }
     public List<CustomerLedgerDE> Leadger { get; set; }

    }
}

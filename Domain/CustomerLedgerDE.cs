using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CustomerLedgerDE
    {
        public int Customer_ID { get; set; }
        public string  Trans_Date {get;set;}
        public string Voucher { get; set;}
        public string Particular { get; set; }
        public decimal GoldOut { get; set; }
        public decimal GoldIn { get; set;}
        public decimal AmountOut { get; set;}
        public decimal AmountIn { get; set;}
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

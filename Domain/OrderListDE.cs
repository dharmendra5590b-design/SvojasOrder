using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OrderListDE
    {
        public List<SelectItem> Design {  get; set; }
        public List<SelectItem> Karat { get; set; }
        public List<SelectItem> DesignType { get; set; }
        public List<SelectItem> GoldColor { get; set; }
        public List<SelectItem> Stones { get; set; }
        public List<SelectItem> ClrStone { get; set; }
        public List<SelectItem> Certificate { get; set; }
        public List<SelectItem> Quality { get; set; }

    }
    public class SelectItem
    {
        public string text {  get; set; }
        public string value { get; set; }
    }
}

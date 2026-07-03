using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OrderCompleteDE
    {
        public int? Order_ID { get; set; }

        public decimal? Final_Gross_Weight { get; set; }
        public int? Final_Noof_Diamonds { get; set; }
        public decimal? Final_Diamond_Weight { get; set; }

        public int? NoOfColour_Stone { get; set; }
        public decimal? ColourStone_Weight { get; set; }

        public int? Others_NoOfColour_Stone { get; set; }
        public decimal? Others_Colour_Stone_Weight { get; set; }

        public decimal? Final_Net_Weight { get; set; }
        public decimal? Final_Amount { get; set; }

        public decimal? Final_Production_Cost { get; set; }
        public decimal? Final_24KT_Gold_Weight { get; set; }
    }
}

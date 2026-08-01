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

        public int? Other_NoOfColour_Stone { get; set; }
        public decimal? Other_Colour_Stone_Weight { get; set; }

        public decimal? Final_Net_Weight { get; set; }
        public decimal? Final_Amount { get; set; }

        public decimal? billAmount { get; set; }
        public decimal? gold24ktWeight { get; set; }

        public decimal? Gold_Loss { get; set; }

        public decimal? Labour_Charge { get; set; }

        public decimal? Gold_Loss_24kt { get; set; }

        public decimal? Production_KT { get; set; }
        public decimal? Diamond_Value { get; set; }
        public decimal? Colour_Stone_Value { get; set; }
        public decimal? Other_Colour_Stone_Value { get; set; }
        public decimal? Final_Net_Weight_24kt { get; set; }
        public decimal? Certificate_Charge { get; set; }
        public decimal? Other_Charges { get; set; }
    }
}

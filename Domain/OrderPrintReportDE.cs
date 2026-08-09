using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OrderPrintReportDE
    {
       
            public string? Order_Number { get; set; }
            public string? Order_DT { get; set; }
            public string? Customer_Name { get; set; }
            public string? Design { get; set; }
            public int? Quantity { get; set; }
            public string? Karat { get; set; }
            public string? Design_Type { get; set; }
            public string? Gold_Colour { get; set; }
            public string? Size { get; set; }
            public string? Stone_Name { get; set; }
            public string? Diamond_Quality { get; set; }
            public string? Cretificate_Name { get; set; }
            public string? Colour_Stone_Name { get; set; }
            public string? Order_Complete_DT { get; set; }

            public decimal? Final_Gross_Weight { get; set; }
            public int? Final_Noof_Diamonds { get; set; }
            public decimal? Final_Diamond_Weight { get; set; }
            public decimal? Diamond_Value { get; set; }

            public int? NoOfColour_Stone { get; set; }
            public decimal? ColourStone_Weight { get; set; }
            public decimal? ColourStone_Value { get; set; }

            public int? Others_NoOfColour_Stone { get; set; }
            public decimal? Others_Colour_Stone_Weight { get; set; }
            public decimal? Other_Colour_Stone_Value { get; set; }

            public decimal? Final_Net_Weight { get; set; }
            public decimal? Final_Net_Weight_24kt { get; set; }
            public decimal? Gold_Loss { get; set; }
            public decimal? Labour_Charge { get; set; }
            public decimal? Gold_Loss_24kt { get; set; }
            public decimal? Certificate_Charge { get; set; }
            public decimal? Other_Charges { get; set; }

            public decimal? Bill_Amount { get; set; }
            public decimal? Final_Gold_Weight_24kt { get; set; }

            public string? CAD_Image_URL { get; set; }
        
    }
}

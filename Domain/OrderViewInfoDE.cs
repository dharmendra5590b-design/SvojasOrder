using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain
{
    public class OrderViewInfoDE
    {
        public int Order_ID { get; set; }
        public string Order_Number { get; set; }
        public string Order_Date { get; set; }

        public string Design { get; set; }
        public string? Quantity { get; set; }

        public string Karat { get; set; }
        public string? Karat_Percent { get; set; }

        public string Design_Type { get; set; }
        public string Gold_Colour { get; set; }

        public string Size { get; set; }
        public string? Weight { get; set; }

        public string Stone_Name { get; set; }
        public bool? Is_Colour_Required { get; set; }

        public string Colour_Stone_Name { get; set; }
        public string? Colour_Stone { get; set; }

        public bool? Is_Certificate_Required { get; set; }
        public string Cretificate_Name { get; set; }

        public string Diamond_Quality { get; set; }
        public string? Diamond_Weight { get; set; }

        public int? NoOf_Diamonds { get; set; }

        public DateTime? Delivery_Date { get; set; }
        public string Specification { get; set; }

        public string Front_Image_URL { get; set; }
        public string Top_Image_URL { get; set; }
        public string Side_Image_URL { get; set; }
        public string Back_Image_URL { get; set; }

        public bool Is_Design_Approved { get; set; }
        public string CAD_Image_URL { get; set; }

        public string? Designer_Weight { get; set; }
        public string? Designer_Diamond_Weight { get; set; }
        public string? Designer_NoOf_Diamonds { get; set; }

        public bool Is_Order_Completed { get; set; }
        public DateTime? Order_Complete_DT { get; set; }

        public string? Final_Gross_Weight { get; set; }
        public int? Final_Noof_Diamonds { get; set; }
        public string? Final_Diamond_Weight { get; set; }

        public int? NoOfColour_Stone { get; set; }
        public string? ColourStone_Weight { get; set; }

        public int? Others_NoOfColour_Stone { get; set; }
        public string? Others_Colour_Stone_Weight { get; set; }

        public string? Final_Net_Weight { get; set; }

        public string Order_Status { get; set; }
        public string adminSpecification { get; set; }
    }
}

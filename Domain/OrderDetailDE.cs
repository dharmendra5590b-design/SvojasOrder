using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OrderDetailDE
    {
        public int Order_ID { get; set; }
        public string Order_Number { get; set; }
        public DateTime? Order_Date { get; set; }
        public int? Customer_ID { get; set; }
        public int? Design_ID { get; set; }
        public int? Karat_ID { get; set; }
        public decimal? Karat_Percent { get; set; }
        public int? Design_Type_ID { get; set; }
        public int? Gold_Colour_ID { get; set; }
        public string Size { get; set; }
        public string Weight { get; set; }

        public int? Stone_ID { get; set; }
        public bool Is_Colour_Required { get; set; }
        public int? Colour_Stone_ID { get; set; }
        public string Colour_Stone { get; set; }
        public string Quantity { get; set; }


        public bool Is_Certificate_Required { get; set; }
        public int? Cretificate_ID { get; set; }
        public int? Diamond_Quality_ID { get; set; }
        public string Diamond_Weight { get; set; }
        public string NoOf_Diamonds { get; set; }

        public DateTime? Delivery_Date { get; set; }
        public string Specification { get; set; }

        public string Front_Image_URL { get; set; }
        public string Top_Image_URL { get; set; }
        public string Side_Image_URL { get; set; }
        public string Back_Image_URL { get; set; }

        public bool IS_Editable { get; set; }

        public bool Is_Design_Approved { get; set; }
        public string CAD_Image_URL { get; set; }

        public decimal? Designer_Weight { get; set; }
        public decimal? Designer_Diamond_Weight { get; set; }
        public int? Designer_NoOf_Diamonds { get; set; }

        public bool Is_Confirmable { get; set; }

        public bool Is_Order_Completed { get; set; }
        public DateTime? Order_Complete_DT { get; set; }

        public decimal? Final_Gross_Weight { get; set; }
        public int? Final_Noof_Diamonds { get; set; }
        public decimal? Final_Diamond_Weight { get; set; }

        public int? NoOfColour_Stone { get; set; }
        public decimal? ColourStone_Weight { get; set; }

        public int? Others_NoOfColour_Stone { get; set; }
        public decimal? Others_Colour_Stone_Weight { get; set; }

        public decimal? Final_Net_Weight { get; set; }
        public decimal? Gold_Loss { get; set; }
        public decimal? Labour_Charge { get; set; }
        public decimal? Gold_Loss_24kt { get; set; }
        public decimal? Bill_Amount { get; set; }
        public decimal? Final_Gold_Weight_24kt { get; set; }
    }
}

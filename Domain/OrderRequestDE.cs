using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OrderRequestDE
    {
        public int? Order_ID { get; set; }
        public int? Customer_ID { get; set; }
        public int? Design_ID { get; set; }
        public int? Karat_ID { get; set; }
        public int? Karat_Percent { get; set; }
        public int? Design_Type_ID { get; set; }
        public int? Gold_Colour_ID { get; set; }

        public string? Size { get; set; }
        public string? Weight { get; set; }
        public string? Quantity { get; set; }
        public int? Stone_ID { get; set; }

        public bool? Is_Colour_Required { get; set; }
        public int? Colour_Stone_ID { get; set; }
        public string? Colour_Stone { get; set; }

        public bool? Is_Certificate_Required { get; set; }
        public int? Cretificate_ID { get; set; }

        public int? Diamond_Quality_ID { get; set; }
        public string? Diamond_Weight { get; set; }
        public string? NoOf_Diamonds { get; set; }

        public DateTime? Delivery_Date { get; set; }

        public string? Specification { get; set; }

        public string? Front_Image_URL { get; set; }
        public string? Top_Image_URL { get; set; }
        public string? Side_Image_URL { get; set; }
        public string? Back_Image_URL { get; set; }
    }
}

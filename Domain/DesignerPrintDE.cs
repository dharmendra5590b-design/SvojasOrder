using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DesignerPrintDE
    {
        public string? Order_Number { get; set; }
        public string? Order_DT { get; set; }
        public string? Design { get; set; }
        public string? Quantity { get; set; }
        public string? Karat { get; set; }
        public string? Design_Type { get; set; }
        public string? Gold_Colour { get; set; }
        public string? Size { get; set; }
        public string? Weight { get; set; }
        public string? Stone_Name { get; set; }
        public string? Diamond_Weight { get; set; }
        public string? NoOf_Diamonds { get; set; }
        public string? Colour_Stone_Name { get; set; }
        public string? NoOf_CLR_Stone { get; set; }
        public string? CLR_Stone_Weight { get; set; }
        public string? Expected_DT { get; set; }
        public string? Priority { get; set; }
        public string? CAD_Image_URL { get; set; }
        public List<string> SpecificationList {  get; set; } 
    }
}

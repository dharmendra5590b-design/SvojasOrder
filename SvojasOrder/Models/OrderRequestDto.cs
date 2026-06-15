namespace SvojasOrder.Models
{
    public class OrderRequestDto
    {
        public int? Customer_ID { get; set; }
        public  int? Order_ID { get; set; }
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
        public int? Certificate_ID { get; set; }

        public int? Diamond_Quality_ID { get; set; }
        public string? Diamond_Weight { get; set; }
        public string? NoOf_Diamonds { get; set; }

        public DateTime? Delivery_Date { get; set; }

        public string? Specification { get; set; }

        public IFormFile? frontImage { get; set; }
        public IFormFile? topImage { get; set; }
        public IFormFile? sideImage { get; set; }
        public IFormFile? backImage { get; set; }

    }
}

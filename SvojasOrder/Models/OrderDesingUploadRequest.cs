namespace SvojasOrder.Models
{
    public class OrderDesingUploadRequest
    {
        public int Order_ID { get; set; }
        public IFormFile CADImage { get; set; }
    }
}

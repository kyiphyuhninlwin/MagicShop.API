namespace Magic_Shop.Models.DTO
{
    public class ProductDto
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public string? Desp { get; set; }
        public DateTime? PublishedDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
    }
}

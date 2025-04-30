namespace Magic_Shop.Models.Domain
{
    public class Variant
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}

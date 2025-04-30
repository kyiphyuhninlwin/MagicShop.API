namespace Magic_Shop.Models.Domain
{
    public class Subcategory
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? TypeID { get; set; }
        public Type? Type { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}

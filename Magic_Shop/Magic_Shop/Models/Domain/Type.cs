namespace Magic_Shop.Models.Domain
{
    public class Type
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public int? CategoryID { get; set; }
        public Category? Category { get; set; }
        public ICollection<Subcategory>? Subcategories { get; set; }
    }
}

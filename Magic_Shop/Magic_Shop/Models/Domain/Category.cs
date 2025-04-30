namespace Magic_Shop.Models.Domain
{
    public class Category
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public ICollection<Type>? Types { get; set; }
    }
}

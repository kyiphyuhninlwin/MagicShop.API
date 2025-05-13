﻿namespace Magic_Shop.Models.Domain
{
    public class Subcategory
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public int? ProductTypeID { get; set; }
        public ProductType? ProductType { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}

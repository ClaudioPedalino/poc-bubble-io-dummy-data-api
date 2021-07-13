using System;

namespace Products.api.Entities
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public decimal Price { get; set; }
    }
}
using Products.api.Data;
using Products.api.Entities;
using Products.api.Interfaces;
using Products.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Products.api.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(Guid productId)
        {
            return _context.Products.FirstOrDefault(x => x.ProductId == productId);
        }

        public string Create(ProductDto dto)
        {
            var entity = new Product
            {
                Description = dto.Description,
                Material = dto.Material,
                Color = dto.Color,
                Price = dto.Price
            };

            _context.Add(entity);
            _context.SaveChanges();
            return $"Create {entity.Description} with price ${entity.Price}";
        }

        public string Delete(Guid productId)
        {
            var entity = _context.Products.FirstOrDefault(x => x.ProductId == productId);
            if (entity == null)
                return $"No product found with id: {productId}";

            _context.Remove(entity);
            _context.SaveChanges();
            return $"Delete product {entity.Description}";
        }
    }
}
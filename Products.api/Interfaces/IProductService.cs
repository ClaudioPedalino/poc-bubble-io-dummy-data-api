using Products.api.Entities;
using Products.api.Models;
using System;
using System.Collections.Generic;

namespace Products.api.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();

        Product GetById(Guid productId);

        string Create(ProductDto dto);

        string Delete(Guid productId);
    }
}
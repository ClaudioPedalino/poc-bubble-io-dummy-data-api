using Bogus;
using Products.api.Entities;
using System;
using System.Collections.Generic;

namespace Products.api.Services
{
    public class DataGenerator : IDataGenerator
    {
        public List<Product> GeneratePersons(int quantity)
        {
            var result = new Faker<Product>()
                .RuleFor(x => x.ProductId, f => Guid.NewGuid())
                .RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
                .RuleFor(x => x.Color, f => f.Commerce.Color())
                .RuleFor(x => x.Material, f => f.Commerce.ProductMaterial())
                .RuleFor(x => x.Price, f => f.Random.Decimal(min: 5, max: 200))
                .Generate(quantity);

            return result;
        }
    }
}
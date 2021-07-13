using Products.api.Entities;
using System.Collections.Generic;

namespace Products.api.Services
{
    public interface IDataGenerator
    {
        List<Product> GeneratePersons(int quantity);
    }
}
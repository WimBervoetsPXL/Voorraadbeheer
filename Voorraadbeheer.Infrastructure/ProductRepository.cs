using System;
using System.Collections.Generic;
using System.Text;
using Voorraadbeheer.Domain;

namespace Voorraadbeheer.Infrastructure
{
    public class ProductRepository
    {
        private List<Product> _products;

        public ProductRepository()
        {
            _products = new List<Product>()
            {
                new Product (1, "Football", 24.99m,  15 ),
                new Product { Id = 2, Name = "Tennis Racket", Price = 89.50m, Stock = 8 },
                new Product { Id = 3, Name = "Basketball", Price = 29.95m, Stock = 12 },
                new Product { Id = 4, Name = "Running Shoes", Price = 120.00m, Stock = 6 },
                new Product { Id = 5, Name = "Sports Towel", Price = 9.99m, Stock = 30 },
                new Product { Id = 6, Name = "Fitness Mat", Price = 19.99m, Stock = 20 },
                new Product { Id = 7, Name = "Boxing Gloves", Price = 59.00m, Stock = 10 },
                new Product { Id = 8, Name = "Swimming Goggles", Price = 14.50m, Stock = 25 },
                new Product { Id = 9, Name = "Jump Rope", Price = 7.95m, Stock = 40 },
                new Product { Id = 10, Name = "Water Bottle", Price = 12.00m, Stock = 18 }
            };
        }

        public List<Product> GetAllProducts()
        {
            return _products.ToList();
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Remove(Product product)
        {
            _products.Remove(product);
        }
    }
}

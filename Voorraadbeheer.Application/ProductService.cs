using System;
using System.Collections.Generic;
using System.Text;
using Voorraadbeheer.Domain;
using Voorraadbeheer.Infrastructure;

namespace Voorraadbeheer.Application
{
    public class ProductService
    {
        private readonly ProductRepository _repository;

        //public ProductService()
        //{
        //    _repository = new ProductRepository();
        //}

        public ProductService(ProductRepository repository)
        {
            _repository = repository;
        }

        public List<Product> GetAllProducts()
        {
            return _repository.GetAllProducts();
        }

        public void AddProduct(int id, string name, decimal price, int stock)
        {
            //controle of product al bestaat?

            Product product = new Product(id, name, price, stock); //Deze regel kan fout veroorzaken!

            _repository.Add(product);
        }

        public void Remove(Product selectedProduct)
        {
            _repository.Remove(selectedProduct);
        }
    }
}

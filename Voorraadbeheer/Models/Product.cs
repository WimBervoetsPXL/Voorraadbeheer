namespace Voorraadbeheer.Models
{
    public class Product
    {
        public Product()
        {
            
        }
        public Product(int id, string name, decimal price, int stock)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if(price <= 0)
            {
                throw new ArgumentException("Price must be greater than 0");
            }

            if (stock <= 0)
            {
                throw new ArgumentException("Stock must be greater than 0");
            }

            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public override string ToString()
        {
            return $"{this.Name} ({this.Stock})";
        }
    }
}
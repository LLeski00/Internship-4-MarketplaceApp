using Marketplace.Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Data.Entities.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public ProductStatus Status { get; set; }

        public Product(string name, string description, double price) { 
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            Status = ProductStatus.OnSale;
        }
    }
}

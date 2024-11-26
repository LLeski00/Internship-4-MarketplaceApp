using MarketplaceApp.Data.Entities.Enums;

namespace MarketplaceApp.Data.Entities.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProductCategory Category { get; set; }
        public double Price { get; set; }
        public ProductStatus Status { get; set; }
        public Vendor Vendor { get; set; }
        public double AverageRating { get; set; }

        public Product(string name, string description, ProductCategory category, double price, Vendor vendor) { 
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Category = category;
            Price = price;
            Status = ProductStatus.OnSale;
            Vendor = vendor;
            AverageRating = 1.00;
        }
    }
}

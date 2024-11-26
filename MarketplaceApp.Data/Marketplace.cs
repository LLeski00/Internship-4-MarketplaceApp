using MarketplaceApp.Data.Entities.Enums;
using MarketplaceApp.Data.Entities.Models;

namespace MarketplaceApp.Data
{
    public static class Marketplace
    {
        public class Context
        {
            public static List<User> Users { get; set; } = Seed.Users;
            public static List<Product> Products { get; set; } = Seed.Products;
            public static List<Tuple<string, ProductCategory, double, DateTime>> Coupons = Seed.Coupons;
        }
    }
}
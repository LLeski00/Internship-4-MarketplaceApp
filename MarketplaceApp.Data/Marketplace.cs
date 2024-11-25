using Marketplace.Data;
using Marketplace.Data.Entities.Models;

namespace MarketplaceApp.Data
{
    public static class Marketplace
    {
        public class Context
        {
            public static List<User> Users { get; set; } = Seed.Users;
            public static List<Product> Products { get; set; } = Seed.Products;
        }
    }
}
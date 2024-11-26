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
            public static List<Coupon> Coupons = Seed.Coupons;
            public static List<Transaction> Transactions = new List<Transaction>();
        }
    }
}
using MarketplaceApp.Data.Entities.Enums;
using MarketplaceApp.Data.Entities.Models;

namespace MarketplaceApp.Data
{
    public static class Seed
    {
        public static readonly List<User> Users = new List<User>() {
            new Customer("Arthur", "Morgan", "arthurmorgan@gmail.com", 250.55),
            new Vendor("John", "Marston", "johnmarston@gmail.com"),
            new Customer("Abigail", "Roberts", "abigail.roberts@gmail.com", 150.30),
            new Vendor("Dutch", "Van der Linde", "dutchvanderlinde@gmail.com"),
            new Customer("Jack", "Marston", "jack.marston@gmail.com", 85.75),
            new Vendor("Sadie", "Adler", "sadie.adler@gmail.com"),
            new Customer("Hosea", "Matthews", "hosea.matthews@gmail.com", 200.00),
            new Vendor("Javier", "Escuella", "javier.escuella@gmail.com"),
            new Customer("Charles", "Smith", "charles.smith@gmail.com", 300.40),
            new Vendor("Bill", "Williamson", "bill.williamson@gmail.com"),
            new Customer("Tilly", "Jackson", "tilly.jackson@gmail.com", 120.10),
            new Vendor("Micah", "Bell", "micah.bell@gmail.com"),
            new Customer("Karen", "Jones", "karen.jones@gmail.com", 75.00),
            new Vendor("Leopold", "Strauss", "leopold.strauss@gmail.com"),
            new Customer("Mary", "Beth", "mary.beth@gmail.com", 180.65),
            new Vendor("Sean", "MacGuire", "sean.macguire@gmail.com"),
            new Customer("Susan", "Grimshaw", "susan.grimshaw@gmail.com", 140.20),
            new Vendor("Josiah", "Trelawny", "josiah.trelawny@gmail.com"),
            new Customer("Pearson", "Cook", "pearson.cook@gmail.com", 95.00),
            new Vendor("Uncle", "Lazybones", "uncle.lazybones@gmail.com"),
            new Customer("Lenny", "Summers", "lenny.summers@gmail.com", 250.50),
            new Vendor("Colm", "O'Driscoll", "colm.odriscoll@gmail.com"),
        };

        public static readonly List<Product> Products = new List<Product>() {
            new Product("Carpenter Repeater", "A solid and balanced gun in a good condition", ProductCategory.Weapons, 15.20, (Vendor)Users[1]),
            new Product("Stolen Horse", "A sturdy but questionable horse of unknown origin", ProductCategory.Pets, 120.00, (Vendor)Users[3]),
            new Product("Crafted Bear Cloak", "Warm cloak made from grizzly bear pelts", ProductCategory.Clothing, 95.00, (Vendor)Users[5]),
            new Product("Lancaster Rifle", "An accurate rifle favored by hunters and marksmen", ProductCategory.Weapons, 45.50, (Vendor)Users[7]),
            new Product("Frontier Hat", "A rugged hat for outlaws and adventurers", ProductCategory.Clothing, 15.75, (Vendor)Users[9]),
            new Product("Deluxe Stew Recipe", "A recipe for a filling and nutritious camp meal", ProductCategory.Food, 7.50, (Vendor)Users[11]),
            new Product("Bolt Action Rifle", "Ideal for long-range engagements and hunting", ProductCategory.Weapons, 55.00, (Vendor)Users[13]),
            new Product("Premium Cigars", "Luxury cigars for the refined outlaw", ProductCategory.Luxury, 12.00, (Vendor)Users[15]),
            new Product("Bow and Arrows", "A silent weapon perfect for hunting or stealth missions", ProductCategory.Weapons, 20.00, (Vendor)Users[1]),
            new Product("Kentucky Bourbon", "Smooth whiskey to soothe the soul", ProductCategory.Food, 8.50, (Vendor)Users[3]),
            new Product("Rare Silver Pocket Watch", "A fine pocket watch with intricate engraving", ProductCategory.Luxury, 65.00, (Vendor)Users[5]),
            new Product("LeMat Revolver", "A unique revolver with a secondary shotgun barrel", ProductCategory.Weapons, 60.00, (Vendor)Users[7]),
            new Product("Fishing Rod", "A sturdy rod perfect for catching fish in rivers and lakes", ProductCategory.Supplies, 15.00, (Vendor)Users[9]),
            new Product("Cattleman Revolver", "Standard sidearm for outlaws and lawmen alike", ProductCategory.Weapons, 25.00, (Vendor)Users[11]),
            new Product("Crafted Alligator Boots", "Stylish boots made from alligator skin", ProductCategory.Clothing, 50.00, (Vendor)Users[13]),
            new Product("Superior Bait", "Effective bait for catching prized fish", ProductCategory.Supplies, 5.00, (Vendor)Users[15]),
            new Product("Fine Chocolate", "Rich chocolate for a quick energy boost", ProductCategory.Food, 3.50, (Vendor)Users[1]),
            new Product("Classic Saddle", "Comfortable saddle with a timeless design", ProductCategory.Pets, 85.00, (Vendor)Users[3]),
            new Product("Horse Reviver", "Medicine to bring your horse back from the brink", ProductCategory.Pets, 10.00, (Vendor)Users[5]),
            new Product("Premium Campfire", "A deluxe campfire for cooking and warmth", ProductCategory.Supplies, 30.00, (Vendor)Users[7]),
            new Product("Velvet Gloves", "Elegant gloves for cold weather or high society", ProductCategory.Clothing, 22.00, (Vendor)Users[9]),
            new Product("Double Barrel Shotgun", "A powerful shotgun for short-range engagements", ProductCategory.Weapons, 70.00, (Vendor)Users[11]),
            new Product("Exotic Bird Feathers", "Rare feathers for crafting or trading", ProductCategory.Supplies, 12.50, (Vendor)Users[13]),
            new Product("Apple Pie", "Freshly baked pie for a taste of home", ProductCategory.Food, 6.00, (Vendor)Users[15]),
            new Product("Crafted Elk Coat", "Durable coat made from elk hide", ProductCategory.Clothing, 80.00, (Vendor)Users[1]),
            new Product("Treasure Map", "Map leading to hidden riches", ProductCategory.Luxury, 25.00, (Vendor)Users[3]),
            new Product("Crafted Snake Oil", "Restores your dead-eye ability and stamina", ProductCategory.Supplies, 5.50, (Vendor)Users[5]),
            new Product("Pearson’s Stew", "A hearty stew cooked by Pearson", ProductCategory.Food, 4.75, (Vendor)Users[7]),
            new Product("Shire Horse", "A dependable and strong workhorse", ProductCategory.Pets, 150.00, (Vendor)Users[9]),
            new Product("Sawed-Off Shotgun", "Compact and powerful shotgun for close quarters", ProductCategory.Weapons, 40.00, (Vendor)Users[11]),
        };

        public static readonly List<Coupon> Coupons = new List<Coupon>() {
            new Coupon("Valentine", 0.1, ProductCategory.Pets, DateTime.Parse("2025-11-23")),
            new Coupon("Saint Denis", 0.15, ProductCategory.Electronics, DateTime.Parse("2025-12-01")),
            new Coupon("Blackwater", 0.2, ProductCategory.Clothing, DateTime.Parse("2025-11-30")),
            new Coupon("Rhodes", 0.1, ProductCategory.Food, DateTime.Parse("2025-11-28")),
            new Coupon("Annesburg", 0.25, ProductCategory.Clothing, DateTime.Parse("2025-12-05")),
            new Coupon("Van Horn", 0.1, ProductCategory.Books, DateTime.Parse("2025-12-10")),
            new Coupon("Strawberry", 0.3, ProductCategory.Weapons, DateTime.Parse("2025-12-03")),
            new Coupon("Armadillo", 0.2, ProductCategory.Weapons, DateTime.Parse("2025-12-08")),
            new Coupon("Tumbleweed", 0.15, ProductCategory.Crafts, DateTime.Parse("2025-11-29")),
            new Coupon("Lagras", 0.1, ProductCategory.Supplies, DateTime.Parse("2025-12-07")),
            new Coupon("Emerald Ranch", 0.2, ProductCategory.Food, DateTime.Parse("2025-12-12")),
        };
    }
}

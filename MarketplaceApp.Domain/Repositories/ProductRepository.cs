using MarketplaceApp.Data.Entities.Enums;
using MarketplaceApp.Data.Entities.Models;
using static MarketplaceApp.Data.Marketplace;

namespace MarketplaceApp.Domain.Repositories
{
    public static class ProductRepository
    {
        public static List<Product> GetAll()
        {
            return Context.Products;
        }

        public static Product? GetById(Guid Id)
        {
            foreach (var item in Context.Products) { 
                if (item.Id == Id)
                    return item;
            }

            return null;
        }

        public static ProductCategory[] GetProductCategories()
        {
            return (ProductCategory[])Enum.GetValues(typeof(ProductCategory));
        }

        public static void AddProduct(string name, string description, ProductCategory category, double price, Vendor owner)
        {
            var product = new Product(name, description, category, price, owner);
            Context.Products.Add(product);
        }

        public static void DisplayAllProducts()
        {
            if (GetAll().Where(i => i.Status == ProductStatus.OnSale) == null || GetAll().Where(i => i.Status == ProductStatus.OnSale).Count() == 0)
            {
                Console.WriteLine("No products!");
                return;
            }

            foreach (var product in GetAll().Where(i => i.Status == ProductStatus.OnSale))
            {
                DisplayProduct(product);
            }
        }

        public static void DisplayVendorsProducts(Vendor owner)
        {
            var vendorsProducts = Context.Products.Where(i => i.Vendor == owner);

            if (vendorsProducts == null || vendorsProducts.Count() == 0) {
                Console.WriteLine("No products!");
                return;
            }

            foreach (var product in vendorsProducts) {
                DisplayProduct(product);
            }
        }

        public static void DisplayPurchasedProducts(Customer user)
        {
            if (user.PurchasedProducts == null || user.PurchasedProducts.Count() == 0)
            {
                Console.WriteLine("No products!");
                return;
            }

            foreach (var product in user.PurchasedProducts)
            {
                DisplayProduct(product);
            }
        }

        public static void DisplayFavoriteProducts(Customer user)
        {
            if (user.FavoriteProducts == null || user.FavoriteProducts.Count() == 0)
            {
                Console.WriteLine("No products!");
                return;
            }

            foreach (var product in user.FavoriteProducts)
            {
                DisplayProduct(product);
            }
        }

        public static void DisplayProduct(Product product)
        {
            Console.WriteLine($"{product.Name}\n\tDescription: {product.Description}\n\tSelling Price: {product.Price} $\n\tID: {product.Id}\n\tCategory: {product.Category}\n\tStatus: {product.Status}\n\tVendor: {product.Vendor.FirstName} {product.Vendor.LastName}");
        }

        public static void DisplayProductCategories()
        {
            ProductCategory[] categories = GetProductCategories();

            foreach (var category in categories) {
                Console.WriteLine(category);
            }
        }

        public static Product? FindProduct()
        {
            Console.WriteLine("Enter the ID of the product:");
            if (!Guid.TryParse(Console.ReadLine(), out var id))
                return null;

            return GetById(id);
        }
    }
}

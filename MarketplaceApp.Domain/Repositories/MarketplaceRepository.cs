using MarketplaceApp.Data.Entities.Enums;
using MarketplaceApp.Data.Entities.Models;
using MarketplaceApp.Domain.Enums;
using static MarketplaceApp.Data.Marketplace;

namespace MarketplaceApp.Domain.Repositories
{
    public static class MarketplaceRepository
    {
        public static List<Transaction> GetAllTransactions()
        {
            return Context.Transactions;
        }

        public static Transaction GetMostRecentTransaction(User user, Product product)
        {
            var transactions = Context.Transactions.Where(i => i.Customer == user && i.ProductId == product.Id);
            return transactions.OrderByDescending(i => i.DateOfPurchase).First();
        }

        public static List<Transaction> GetTransactionsInPeriod(User user, DateTime startDate, DateTime endDate)
        {
            return Context.Transactions.Where(i => i.Vendor == user && i.DateOfPurchase >= startDate && i.DateOfPurchase <= endDate).ToList();
        }

        public static ResponseResultType Buy(Customer user, Product product, double discount)
        {
            var priceToPay = (product.Price * (1 - discount) + product.Price * Context.Provision);

            if (user.Balance < priceToPay)
            {
                return ResponseResultType.InsufficientFunds;
            }

            user.Balance -= priceToPay;
            product.Vendor.Profit += product.Price;
            product.Status = ProductStatus.Sold;
            user.PurchasedProducts.Add(product);

            Context.Transactions.Add(new Transaction(product.Id, user, product.Vendor, DateTime.Now, priceToPay));

            return ResponseResultType.Success;
        }

        public static void Return(Customer user, Product product)
        {
            var pricePaid = GetMostRecentTransaction(user, product).PricePaid;
            user.Balance += pricePaid * 0.8;
            user.PurchasedProducts.Remove(product);
            product.Vendor.Profit -= pricePaid * 0.85;
            product.Status = ProductStatus.OnSale;
        }

        public static double InputCoupon(Product product)
        {
            Console.WriteLine("Enter coupon:");
            var couponCode = Console.ReadLine();

            return GetDiscount(couponCode, product);
        }

        public static double GetDiscount(string? couponCode, Product product)
        {
            foreach (var coupon in Context.Coupons)
            {
                if (coupon.Code == couponCode)
                {
                    if (coupon.ExpiryDate < DateTime.Now)
                    {
                        Console.WriteLine("The coupon has expired!");
                        return 0.00;
                    }
                    
                    if (coupon.Category != product.Category)
                    {
                        Console.WriteLine("The coupon is not valid for the product!");
                        return 0.00;
                    }

                    Console.WriteLine($"Successfully redeemed coupon! Discount: {coupon.Discount * 100} %, New price: {product.Price * (1 - coupon.Discount)} $");
                    return coupon.Discount;
                }
            }

            Console.WriteLine("Coupon doesn't exist!");
            return 0.00;
        }

        public static double GetProvision()
        {
            return Context.Provision;
        }
    }
}

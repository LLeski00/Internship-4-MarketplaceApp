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

        public static ResponseResultType Buy(Customer user, Product product, double discount)
        {
            if (user.Balance < product.Price)
            {
                return ResponseResultType.InsufficientFunds;
            }

            user.Balance -= product.Price * (1 - discount);
            product.Vendor.Profit += product.Price;
            product.Status = ProductStatus.Sold;
            user.PurchasedProducts.Add(product);

            Context.Transactions.Add(new Transaction(product.Id, user, product.Vendor, DateTime.Now));

            return ResponseResultType.Success;
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

                    Console.WriteLine($"Successfully redeemed coupon! Discount: {coupon.Discount * 100} %");
                    return coupon.Discount;
                }
            }

            Console.WriteLine("Coupon doesn't exist!");
            return 0.00;
        }
    }
}

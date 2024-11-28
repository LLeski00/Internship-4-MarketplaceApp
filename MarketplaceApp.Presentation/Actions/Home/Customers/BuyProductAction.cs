using MarketplaceApp.Data.Entities.Enums;
using MarketplaceApp.Data.Entities.Models;
using MarketplaceApp.Domain.Enums;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Extensions;
using MarketplaceApp.Presentation.Helpers;

namespace MarketplaceApp.Presentation.Actions.Home.Customers
{
    public class BuyProductAction : IAction
    {
        public string Name { get; set; } = "Buy a product";
        public Customer User { get; set; }
        public int MenuIndex { get; set; }

        public BuyProductAction(Customer user) {
            User = user;
        }

        public void Open()
        {
            Writer.ConsoleClear();

            if (ActionExtensions.AskFilterChoice(out var category))
                ProductRepository.DisplayAllProducts((ProductCategory)category);
            else
                ProductRepository.DisplayAllProducts();

            Console.WriteLine($"\n\tDISCLAIMER\nMarketplace provision of {MarketplaceRepository.GetProvision() * 100}% is not included in the price.");
            Console.WriteLine($"Your balance: {User.Balance:F2} $");
            var product = ProductRepository.FindProduct();
            var discount = 0.00;

            while (product == null)
            {
                Writer.Error("Product not found!");

                if (Reader.DoYouWantToContinue())
                    Open();

                return;
            }

            if (product.Status == ProductStatus.Sold) 
            {
                Writer.Error("Product already sold!");

                if (Reader.DoYouWantToContinue())
                    Open();

                return;
            }

            Console.WriteLine("Press y if you have coupon code.");

            if (Console.ReadLine() == "y")
            {
                discount = MarketplaceRepository.InputCoupon(product);

                if (discount == 0.00)
                {
                    if (Reader.DoYouWantToContinue())
                        Open();

                    return;
                }
            }

            if (MarketplaceRepository.Buy(User, product, discount) != ResponseResultType.Success)
            {
                Writer.Error("Insufficient funds.");

                if (Reader.DoYouWantToContinue())
                    Open();

                return;
            }

            Console.WriteLine("Product successfully purchased!");
            Console.ReadLine();
        }


    }
}

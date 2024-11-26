using MarketplaceApp.Data.Entities.Models;
using MarketplaceApp.Domain.Enums;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Extensions;
using MarketplaceApp.Presentation.Helpers;

namespace MarketplaceApp.Presentation.Actions.Home.Products
{
    public class BuyProductAction : IAction
    {
        public string Name { get; set; } = "Buy a product";
        public Customer? User { get; set; }
        public int MenuIndex { get; set; }

        public BuyProductAction(Customer user) {
            User = user;
        }

        public void Open()
        {
            ActionExtensions.DisplayAllProducts();
            var product = ActionExtensions.FindProduct();
            var discount = 0.00;

            while (product == null)
            {
                Writer.Error("Product not found!");

                if (!Reader.DoYouWantToContinue())
                    return;

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
                    {
                        Open();
                        return;
                    }
                    else
                        return;
                }
            }

            if (MarketplaceRepository.Buy(User, product, discount) != ResponseResultType.Success)
            {
                Writer.Error("Insufficient funds.");

                if (!Reader.DoYouWantToContinue())
                    return;
                else
                {
                    Open();
                    return;
                }
            }

            Console.WriteLine("Product successfully purchased!");
            Console.ReadLine();
        }


    }
}

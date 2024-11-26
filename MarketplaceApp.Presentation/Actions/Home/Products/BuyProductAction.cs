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
        public User? User { get; set; }
        public int MenuIndex { get; set; }

        public BuyProductAction(User? user) {
            User = user;
        }

        public void Open()
        {
            ActionExtensions.DisplayAllProducts();
            var product = ActionExtensions.FindProduct();

            while (product == null)
            {
                Writer.Error("Product not found!");

                if (!Reader.DoYouWantToContinue())
                    return;

                product = ActionExtensions.FindProduct();
            }

            if (MarketplaceRepository.Buy((Customer)User, product) != ResponseResultType.Success)
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

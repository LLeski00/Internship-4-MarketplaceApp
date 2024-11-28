using MarketplaceApp.Data.Entities.Enums;
using MarketplaceApp.Data.Entities.Models;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Extensions;
using MarketplaceApp.Presentation.Helpers;

namespace MarketplaceApp.Presentation.Actions.Home.Customers
{
    public class ReturnProductAction : IAction
    {
        public string Name { get; set; } = "Return a product";
        public Customer User { get; set; }
        public int MenuIndex { get; set; }

        public ReturnProductAction(Customer user)
        {
            User = user;
        }

        public void Open()
        {
            Writer.ConsoleClear();

            if (User.PurchasedProducts == null || User.PurchasedProducts.Count() == 0)
            {
                Console.WriteLine("No purchased products found!");
                Console.ReadLine();
                return;
            }

            if (ActionExtensions.AskFilterChoice(out var category))
                ProductRepository.DisplayPurchasedProducts(User, (ProductCategory)category);
            else
                ProductRepository.DisplayPurchasedProducts(User);

            Console.WriteLine("Return a product:");
            var productToReturn = ProductRepository.FindProduct();

            while (productToReturn == null)
            {
                Writer.Error("Product not found!");

                if (Reader.DoYouWantToContinue())
                    Open();

                return;
            }

            if (!User.PurchasedProducts.Contains(productToReturn))
            {
                Writer.Error("This product is not purchased!");

                if (Reader.DoYouWantToContinue())
                    Open();

                return;
            }

            MarketplaceRepository.Return(User, productToReturn);
            Console.WriteLine("Product successfully returned!");
            Console.ReadLine();
        }
    }
}

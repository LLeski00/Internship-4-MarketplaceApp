using MarketplaceApp.Data.Entities.Models;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Helpers;

namespace MarketplaceApp.Presentation.Actions.Home.Users
{
    public class AddToFavoritesAction : IAction
    {
        public string Name { get; set; } = "Add product to favorites";
        public Customer User { get; set; }
        public int MenuIndex { get; set; }

        public AddToFavoritesAction(Customer user)
        {
            User = user;
        }

        public void Open()
        {
            Writer.ConsoleClear();
            ProductRepository.DisplayAllProducts();
            var product = ProductRepository.FindProduct();

            while (product == null)
            {
                Writer.Error("Product not found!");

                if (Reader.DoYouWantToContinue())
                    Open();

                return;
            }

            User.FavoriteProducts.Add(product);
            Console.WriteLine("Successfully added product to favorites.");
            Console.ReadLine();
        }
    }
}

using MarketplaceApp.Data.Entities.Enums;
using MarketplaceApp.Data.Entities.Models;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Extensions;
using MarketplaceApp.Presentation.Helpers;

namespace MarketplaceApp.Presentation.Actions.Home.Customers
{
    public class DisplayFavoritesAction : IAction
    {
        public string Name { get; set; } = "Display favorite products";
        public Customer User { get; set; }
        public int MenuIndex { get; set; }

        public DisplayFavoritesAction(Customer user)
        {
            User = user;
        }

        public void Open()
        {
            Writer.ConsoleClear();

            if (ActionExtensions.AskFilterChoice(out var category))
                ProductRepository.DisplayFavoriteProducts(User, (ProductCategory)category);
            else
                ProductRepository.DisplayFavoriteProducts(User);

            Console.ReadLine();
        }
    }
}

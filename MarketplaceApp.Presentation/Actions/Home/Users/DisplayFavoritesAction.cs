using MarketplaceApp.Data.Entities.Models;
using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Extensions;
using MarketplaceApp.Presentation.Helpers;

namespace MarketplaceApp.Presentation.Actions.Home.Users
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
            ActionExtensions.DisplayFavoriteProducts(User);
            Console.ReadLine();
        }
    }
}

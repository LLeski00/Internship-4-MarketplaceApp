using MarketplaceApp.Data.Entities.Models;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Abstractions;
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
            ProductRepository.DisplayFavoriteProducts(User);
            Console.ReadLine();
        }
    }
}

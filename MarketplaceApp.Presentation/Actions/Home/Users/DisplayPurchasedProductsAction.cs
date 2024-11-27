using MarketplaceApp.Data.Entities.Models;
using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Extensions;
using MarketplaceApp.Presentation.Helpers;

namespace MarketplaceApp.Presentation.Actions.Home.Users
{
    public class DisplayPurchasedProductsAction : IAction
    {
        public string Name { get; set; } = "Display purchased products";
        public Customer User { get; set; }
        public int MenuIndex { get; set; }

        public DisplayPurchasedProductsAction(Customer user)
        {
            User = user;
        }

        public void Open()
        {
            Writer.ConsoleClear();
            ActionExtensions.DisplayPurchasedProducts(User);
            Console.ReadLine();
        }
    }
}

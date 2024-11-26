using MarketplaceApp.Data.Entities.Models;
using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Extensions;
using MarketplaceApp.Presentation.Helpers;

namespace MarketplaceApp.Presentation.Actions.Home.Products
{
    public class DisplayProductsAction : IAction
    {
        public string Name { get; set; } = "Display products";
        public int MenuIndex { get; set; }

        public void Open()
        {
            Writer.ConsoleClear();
            ActionExtensions.DisplayAllProducts();
            Console.ReadLine();
        }
    }
}

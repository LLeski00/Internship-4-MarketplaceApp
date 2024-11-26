using MarketplaceApp.Data.Entities.Models;
using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Extensions;
using MarketplaceApp.Presentation.Helpers;

namespace MarketplaceApp.Presentation.Actions.Home.Products
{
    public class DisplayProductsOnSaleAction : IAction
    {
        public string Name { get; set; } = "Display products on sale";
        public int MenuIndex { get; set; }

        public void Open()
        {
            Writer.ConsoleClear();
            ActionExtensions.DisplayAllProducts();
            Console.ReadLine();
        }
    }
}

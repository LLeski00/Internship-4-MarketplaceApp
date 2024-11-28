using MarketplaceApp.Data.Entities.Enums;
using MarketplaceApp.Domain.Repositories;
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

            if (ActionExtensions.AskFilterChoice(out var category))
                ProductRepository.DisplayAllProducts((ProductCategory)category);
            else
                ProductRepository.DisplayAllProducts();

            Console.ReadLine();
        }
    }
}

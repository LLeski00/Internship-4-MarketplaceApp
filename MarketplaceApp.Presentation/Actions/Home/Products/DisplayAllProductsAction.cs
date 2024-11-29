using MarketplaceApp.Data.Entities.Enums;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Extensions;
using MarketplaceApp.Presentation.Helpers;

namespace MarketplaceApp.Presentation.Actions.Home.Products
{
    public class DisplayAllProductsAction : IAction
    {
        public string Name { get; set; } = "Display all products";
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

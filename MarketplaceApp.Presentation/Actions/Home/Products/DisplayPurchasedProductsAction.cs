using MarketplaceApp.Data.Entities.Models;
using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Extensions;
using MarketplaceApp.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Presentation.Actions.Home.Products
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

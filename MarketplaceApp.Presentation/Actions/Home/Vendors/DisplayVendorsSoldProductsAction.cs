using MarketplaceApp.Data.Entities.Enums;
using MarketplaceApp.Data.Entities.Models;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Extensions;
using MarketplaceApp.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Presentation.Actions.Home.Vendors
{
    public class DisplayVendorsSoldProductsAction : IAction
    {

        public string Name { get; set; } = "Display your sold products";
        public Vendor Vendor { get; set; }
        public int MenuIndex { get; set; }

        public DisplayVendorsSoldProductsAction(Vendor vendor)
        {
            Vendor = vendor;
        }

        public void Open()
        {
            Writer.ConsoleClear();

            if (ActionExtensions.AskFilterChoice(out var category))
                ProductRepository.DisplayVendorsSoldProducts(Vendor, (ProductCategory)category);
            else
                ProductRepository.DisplayVendorsSoldProducts(Vendor);

            Console.ReadLine();
        }
    }
}

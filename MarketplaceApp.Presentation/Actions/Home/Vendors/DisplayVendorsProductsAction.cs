﻿using MarketplaceApp.Data.Entities.Enums;
using MarketplaceApp.Data.Entities.Models;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Extensions;
using MarketplaceApp.Presentation.Helpers;

namespace MarketplaceApp.Presentation.Actions.Home.Vendors
{
    public class DisplayVendorsProductsAction : IAction
    {

        public string Name { get; set; } = "Display your products";
        public Vendor Vendor { get; set; }
        public int MenuIndex { get; set; }

        public DisplayVendorsProductsAction(Vendor vendor)
        {
            Vendor = vendor;
        }

        public void Open()
        {
            Writer.ConsoleClear();

            if (ActionExtensions.AskFilterChoice(out var category))
                ProductRepository.DisplayVendorsProducts(Vendor, (ProductCategory)category);
            else
                ProductRepository.DisplayVendorsProducts(Vendor);

            Console.ReadLine();
        }
    }
}

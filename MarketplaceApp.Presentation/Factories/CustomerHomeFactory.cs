﻿using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Actions.Home.Products;
using MarketplaceApp.Presentation.Actions.Home;
using MarketplaceApp.Presentation.Extensions;
using MarketplaceApp.Data.Entities.Models;

namespace MarketplaceApp.Presentation.Factories
{
    public class CustomerHomeFactory
    {
        public static IList<IAction> CreateActions(Customer user)
        {
            var actions = new List<IAction>()
            {
                new ExitMenuAction(),
                new DisplayProductsOnSaleAction(),
                new DisplayPurchasedProductsAction(user),
                new BuyProductAction(user),
            };

            actions.SetActionIndexes();
            
            return actions;
        }
    }
}

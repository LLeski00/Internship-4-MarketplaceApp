﻿using MarketplaceApp.Data.Entities.Models;
using MarketplaceApp.Presentation.Helpers;
using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Factories;
using MarketplaceApp.Presentation.Actions.Home;
using MarketplaceApp.Data.Entities.Enums;
using MarketplaceApp.Domain.Repositories;
using static MarketplaceApp.Data.Marketplace;

namespace MarketplaceApp.Presentation.Extensions
{
    public static class ActionExtensions
    {
        public static void DisplayMenu(this IList<IAction> actions)
        {
            const string INVALID_INPUT_MSG = "Please type in number!";
            const string INVALID_ACTION_MSG = "Please select valid action!";

            var isExitSelected = false;
            do
            {
                DisplayActions(actions);

                var isValidInput = int.TryParse(Console.ReadLine(), out var actionIndex);
                if (!isValidInput)
                {
                    Writer.Error(INVALID_INPUT_MSG);
                    continue;
                }

                var action = actions.FirstOrDefault(a => a.MenuIndex == actionIndex);
                if (action is null)
                {
                    Writer.Error(INVALID_ACTION_MSG);
                    continue;
                }

                if (action is ExitMenuAction)
                    isExitSelected = true;

                action.Open();
            } while (!isExitSelected);
        }

        public static void SetActionIndexes(this IList<IAction> actions)
        {
            var index = 0;
            foreach (var action in actions)
            {
                action.MenuIndex = ++index;
            }
        }

        public static void DisplayMainMenu()
        {
            MainMenuFactory.CreateActions().DisplayMenu();
        }

        public static void DisplayCustomerHomeMenu(Customer user)
        {
            CustomerHomeFactory.CreateActions(user).DisplayMenu();
        }

        public static void DisplayVendorHomeMenu(Vendor user)
        {
            VendorHomeFactory.CreateActions(user).DisplayMenu();
        }

        private static void DisplayActions(IList<IAction> actions)
        {
            Console.Clear();

            foreach (var action in actions)
            {
                Console.WriteLine($"{action.MenuIndex}. {action.Name}");
            }
        }

        public static void DisplayAllProducts()
        {
            foreach (var product in ProductRepository.GetAll().Where(i => i.Status == ProductStatus.OnSale))
            {
                DisplayProduct(product);
            }
        }

        public static void DisplayProduct(Product product)
        {
            Console.WriteLine($"{product.Name}\n\tDescription: {product.Description}\n\tPrice: {product.Price} $\n\tID: {product.Id}\n\tCategory: {product.Category}\n\tAverage rating: {product.AverageRating}\n\tOwner: {product.Owner.FirstName} {product.Owner.LastName}");
        }

        public static Product? FindProduct()
        {
            Console.WriteLine("Enter the ID of the product:");
            var id = Console.ReadLine();

            foreach (var product in Context.Products)
            {
                if (product.Id.ToString() == id)
                {
                    return product;
                }
            }

            return null;
        }
    }
}

using Marketplace.Data.Entities.Models;
using MarketplaceApp.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Factories;
using MarketplaceApp.Presentation.Actions.Home;

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

        public static void DisplayCustomerHomeMenu()
        {
            CustomerHomeFactory.CreateActions().DisplayMenu();
        }

        public static void DisplayVendorHomeMenu()
        {
            VendorHomeFactory.CreateActions().DisplayMenu();
        }

        private static void DisplayActions(IList<IAction> actions)
        {
            Console.Clear();

            foreach (var action in actions)
            {
                Console.WriteLine($"{action.MenuIndex}. {action.Name}");
            }
        }
    }
}

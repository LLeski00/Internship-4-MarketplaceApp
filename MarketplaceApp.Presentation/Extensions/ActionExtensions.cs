using MarketplaceApp.Data.Entities.Models;
using MarketplaceApp.Presentation.Helpers;
using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Factories;
using MarketplaceApp.Presentation.Actions.Home;
using MarketplaceApp.Data.Entities.Enums;
using MarketplaceApp.Domain.Repositories;

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
                Writer.ConsoleClear();
                Console.WriteLine("\tMarketplace App\n");
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
            foreach (var action in actions)
            {
                Console.WriteLine($"{action.MenuIndex}. {action.Name}");
            }
        }

        public static bool AskFilterChoice(out ProductCategory? category)
        {
            Console.WriteLine("Press y if you want to filter the display by category:");

            var filterOption = Console.ReadLine();

            if (filterOption != null && filterOption != string.Empty && filterOption.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                do
                {
                    category = GetCategoryChoice();

                    if (category == null)
                    {
                        Writer.Error("Invalid category!");

                        if (Reader.DoYouWantToContinue())
                            continue;

                        return false;
                    }

                    return true;
                } while (true);
            }

            category = null;
            return false;
        }

        public static ProductCategory? GetCategoryChoice()
        {
            Console.WriteLine("All possible product categories: ");
            ProductRepository.DisplayProductCategories();

            if (!Reader.TryReadProductCategory("Enter the category: ", out var category))
            {
                return null;
            }

            return (ProductCategory)Enum.Parse(typeof(ProductCategory), category);
        }
    }
}

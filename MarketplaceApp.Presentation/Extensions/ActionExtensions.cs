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

namespace MarketplaceApp.Presentation.Extensions
{
    public static class ActionExtensions
    {
        public static void PrintActionsAndOpen(this IList<IAction> actions)
        {
            const string INVALID_INPUT_MSG = "Please type in number!";
            const string INVALID_ACTION_MSG = "Please select valid action!";

            var isExitSelected = false;
            do
            {
                PrintActions(actions);

                var isValidInput = int.TryParse(Console.ReadLine(), out var actionIndex);
                if (!isValidInput)
                {
                    PrintErrorMessage(INVALID_INPUT_MSG);
                    continue;
                }

                var action = actions.FirstOrDefault(a => a.MenuIndex == actionIndex);
                if (action is null)
                {
                    PrintErrorMessage(INVALID_ACTION_MSG);
                    continue;
                }
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
        public static void PrintActions()
        {
            MainMenuFactory.CreateActions().PrintActionsAndOpen();
        }
        private static void PrintActions(IList<IAction> actions)
        {
            Console.Clear();

            foreach (var action in actions)
            {
                Console.WriteLine($"{action.MenuIndex}. {action.Name}");
            }
        }

        private static void PrintErrorMessage(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }

        public static string? EmailChoice()
        {
            Console.Clear();
            string? email = Reader.ReadInput();
            return email;
        }
        public static string? IsCorrectPassword()
        {
            Reader.TryReadLine("Enter your choosen password", out string password);
            Reader.TryReadLine("Enter your choosen password again", out string secondTryPassword);
            if (password == secondTryPassword)
                return password;
            return null;
        }
        public static string CorrectPasswordChoice()
        {
            string? password = IsCorrectPassword();
            while (password == null)
            {
                bool cont = Reader.DoYouWantToContinue();
                if (cont)
                    password = IsCorrectPassword();
                else
                    PrintActions();
            }
            return password;
        }
        public static string CorrectEmailChoice()
        {
            string? email = Reader.ReadInput();
            while (email == null)
            {
                bool cont = Reader.DoYouWantToContinue();
                if (cont)
                    email = EmailChoice();
                else
                    PrintActions();
            }
            return email;
        }
    }
}

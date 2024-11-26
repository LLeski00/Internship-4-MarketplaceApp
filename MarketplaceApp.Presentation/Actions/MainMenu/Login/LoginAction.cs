using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Extensions;
using MarketplaceApp.Presentation.Helpers;
using MarketplaceApp.Data.Entities.Models;
using MarketplaceApp.Domain.Repositories;

namespace MarketplaceApp.Presentation.Actions.MainMenu.Login
{
    public class LoginAction : IAction
    {
        public string Name { get; set; } = "Log in";
        public int MenuIndex { get; set; }

        public void Open()
        {
            User? user = FindUser();

            while (user == null)
            {
                Console.WriteLine("The user was not found.");

                if (Reader.DoYouWantToContinue())
                    user = FindUser();
                else
                {
                    ActionExtensions.DisplayMainMenu();
                    return;
                }
            }

            if (user is Customer)
                ActionExtensions.DisplayCustomerHomeMenu(user);
            else
                ActionExtensions.DisplayVendorHomeMenu(user);
        }

        public User? FindUser()
        {
            Console.Clear();
            if (!Reader.TryReadEmail("Enter your email: ", out string? email))
            {
                Writer.Error("Email invalid!");
                return null;
            }

            User? user = UserRepository.GetUser(email);
            return user;
        }
    }
}

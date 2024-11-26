using Marketplace.Data.Entities.Models;
using Marketplace.Domain.Repositories;
using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Extensions;
using MarketplaceApp.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace MarketplaceApp.Presentation.Actions.MainMenu.Login
{
    public class LoginAction : IAction
    {
        public string Name { get; set; } = "Log in";
        public User? User { get; set; }
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
                ActionExtensions.DisplayCustomerHomeMenu();
            else
                ActionExtensions.DisplayVendorHomeMenu();
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

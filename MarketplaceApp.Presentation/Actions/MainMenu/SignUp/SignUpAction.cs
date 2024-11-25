using Marketplace.Data.Entities.Models;
using Marketplace.Domain.Enums;
using Marketplace.Domain.Repositories;
using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Extensions;
using MarketplaceApp.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Presentation.Actions.MainMenu.SignUp
{
    public class SingUpAction : IAction
    {
        public string Name { get; set; } = "Sign up";
        public User? User { get; set; }
        public int MenuIndex { get; set; }

        public SingUpAction()
        {
        }

        public void Open()
        {
            do
            {
                Console.Clear();

                if (!Reader.TryReadName("Enter first name:", out var firstName))
                {
                    Writer.Error("Invalid first name!");

                    if (!Reader.DoYouWantToContinue())
                        break;

                    continue;
                }

                if (!Reader.TryReadName("Enter last name:", out var lastName))
                {
                    Writer.Error("Invalid last name!");

                    if (!Reader.DoYouWantToContinue())
                        break;

                    continue;
                }

                var email = ActionExtensions.CorrectEmailChoice();

                if (UserRepository.GetUser(email) != null)
                {
                    Writer.Error("This email is already taken.");
                    ActionExtensions.PrintActions();
                    continue;
                }

                var newUser = new User(firstName, lastName, email);

                if (UserRepository.Add(newUser) is ResponseResultType.Success)
                {
                    Writer.Write(newUser);
                    Console.ReadKey();
                    break;
                }

                Console.WriteLine("Failed to add user, no changes saved!");
                Console.ReadLine();

                if (!Reader.DoYouWantToContinue())
                    break;
            } while (true);
        }
    }
}

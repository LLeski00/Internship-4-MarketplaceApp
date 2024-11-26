using MarketplaceApp.Data.Entities.Models;
using MarketplaceApp.Domain.Enums;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Helpers;

namespace MarketplaceApp.Presentation.Actions.MainMenu.SignUp
{
    public class SingUpAction : IAction
    {
        public string Name { get; set; } = "Sign up";
        public int MenuIndex { get; set; }

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

                if (!Reader.TryReadEmail("Enter Email:", out var email))
                {
                    Writer.Error("Invalid Email!");

                    if (!Reader.DoYouWantToContinue())
                        break;

                    continue;
                }

                if (UserRepository.GetUser(email) != null)
                {
                    Writer.Error("This email is already taken.");

                    if (!Reader.DoYouWantToContinue())
                        break;

                    continue;
                }

                if (!Reader.TryReadNumber("Choose:\n1. Customer\n2. Vendor", out var typeOfAccount))
                {
                    Writer.Error("Not a number!");

                    if (!Reader.DoYouWantToContinue())
                        break;

                    continue;
                }

                User newUser;

                if (typeOfAccount == 1)
                {
                    Console.WriteLine("Enter starting balance:");

                    if (!double.TryParse(Console.ReadLine(), out var balance))
                    {
                        Writer.Error("Not a number!");

                        if (!Reader.DoYouWantToContinue())
                            break;

                        continue;
                    }

                    newUser = new Customer(firstName, lastName, email, balance);
                }
                else if (typeOfAccount == 2)
                    newUser = new Vendor(firstName, lastName, email);
                else
                {
                    Writer.Error("Option doesn't exist!");

                    if (!Reader.DoYouWantToContinue())
                        break;

                    continue;
                }

                if (UserRepository.Add(newUser) is ResponseResultType.Success)
                {
                    Console.WriteLine("User successfully added");
                    Console.ReadKey();
                    break;
                }

                Writer.Error("Failed to add user, no changes saved!");

                if (!Reader.DoYouWantToContinue())
                    break;

            } while (true);
        }
    }
}

using MarketplaceApp.Data.Entities.Enums;
using MarketplaceApp.Data.Entities.Models;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Extensions;
using MarketplaceApp.Presentation.Helpers;

namespace MarketplaceApp.Presentation.Actions.Home.Vendors
{
    public class AddProductAction : IAction
    {
        
        public string Name { get; set; } = "Add a product to sell";
        public Vendor Vendor { get; set; }
        public int MenuIndex { get; set; }

        public AddProductAction(Vendor vendor)
        {
            Vendor = vendor;
        }

        public void Open()
        {
            do
            {
                Writer.ConsoleClear();

                if (!Reader.TryReadName("Enter the name of the product:", out var name))
                {
                    Writer.Error("Invalid name!");

                    if (!Reader.DoYouWantToContinue())
                        break;

                    continue;
                }

                Console.WriteLine("Enter the product's description:");
                var description = Console.ReadLine();

                if (description == null || description == string.Empty)
                {
                    Writer.Error("Please enter the description!");

                    if (!Reader.DoYouWantToContinue())
                        break;

                    continue;
                }

                Console.WriteLine("Enter the price you wish to sell the product for:");

                if (!double.TryParse(Console.ReadLine(), out var price) || price < 0)
                {
                    Writer.Error("Invalid price!");

                    if (!Reader.DoYouWantToContinue())
                        break;

                    continue;
                }

                var category = ActionExtensions.GetCategoryChoice();

                if (category == null)
                {
                    Writer.Error("Invalid category!");

                    if (!Reader.DoYouWantToContinue())
                        break;

                    continue;
                }

                ProductRepository.AddProduct(name, description, (ProductCategory)category, price, Vendor);
                Console.WriteLine("Product successfully added");
                Console.ReadKey();
                break;
            } while (true);
        }
        
    }
}

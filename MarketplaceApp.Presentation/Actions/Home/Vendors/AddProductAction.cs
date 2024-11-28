using MarketplaceApp.Data.Entities.Enums;
using MarketplaceApp.Data.Entities.Models;
using MarketplaceApp.Domain.Enums;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Abstractions;
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

                if (!double.TryParse(Console.ReadLine(), out var price))
                {
                    Writer.Error("Not a number!");

                    if (!Reader.DoYouWantToContinue())
                        break;

                    continue;
                }

                Console.WriteLine("All possible product categories: ");
                ProductRepository.DisplayProductCategories();
                Reader.TryReadProductCategory("Enter the category: ", out var category);
                ProductRepository.AddProduct(name, description, (ProductCategory)Enum.Parse(typeof(ProductCategory), category), price, Vendor);
                Console.WriteLine("Product successfully added");
                Console.ReadKey();
                break;
            } while (true);
        }
        
    }
}

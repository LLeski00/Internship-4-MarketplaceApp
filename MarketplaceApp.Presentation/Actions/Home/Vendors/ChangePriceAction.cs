using MarketplaceApp.Data.Entities.Enums;
using MarketplaceApp.Data.Entities.Models;
using MarketplaceApp.Domain.Enums;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Extensions;
using MarketplaceApp.Presentation.Helpers;

namespace MarketplaceApp.Presentation.Actions.Home.Vendors
{
    public class ChangePriceAction : IAction
    {
        public string Name { get; set; } = "Change the price of a product";
        public Vendor Vendor { get; set; }
        public int MenuIndex { get; set; }

        public ChangePriceAction(Vendor vendor)
        {
            Vendor = vendor;
        }

        public void Open()
        {
            Writer.ConsoleClear();

            if (ActionExtensions.AskFilterChoice(out var category))
                ProductRepository.DisplayVendorsProducts(Vendor, (ProductCategory)category);
            else
                ProductRepository.DisplayVendorsProducts(Vendor);

            var product = ProductRepository.FindProduct();

            while (product == null)
            {
                Writer.Error("Product not found!");

                if (Reader.DoYouWantToContinue())
                    Open();

                return;
            }

            if (product.Vendor != Vendor)
            {
                Writer.Error("You do not own this product!");

                if (Reader.DoYouWantToContinue())
                    Open();

                return;
            }

            if (product.Status == ProductStatus.Sold)
            {
                Writer.Error("This product is already sold!");

                if (Reader.DoYouWantToContinue())
                    Open();

                return;
            }

            Console.WriteLine("Enter the new price: ");
            if (!double.TryParse(Console.ReadLine(), out var newPrice))
            {
                Writer.Error("Not a number!");

                if (Reader.DoYouWantToContinue())
                    Open();

                return;
            }

            if (ProductRepository.ChangePrice(product, newPrice) != ResponseResultType.Success){
                Writer.Error("Invalid new price!");

                if (Reader.DoYouWantToContinue())
                    Open();

                return;
            }

            Console.WriteLine("Price sucessfully changed!");
            Console.ReadLine();
        }
    }
}

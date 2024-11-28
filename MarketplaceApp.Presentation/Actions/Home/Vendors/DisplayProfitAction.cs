using MarketplaceApp.Data.Entities.Models;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Helpers;

namespace MarketplaceApp.Presentation.Actions.Home.Vendors
{
    public class DisplayProfitAction : IAction
    {

        public string Name { get; set; } = "Display profit";
        public Vendor Vendor { get; set; }
        public int MenuIndex { get; set; }

        public DisplayProfitAction(Vendor vendor)
        {
            Vendor = vendor;
        }

        public void Open()
        {
            Writer.ConsoleClear();
            Console.WriteLine($"Your profit: {Vendor.Profit:F2} $");
            Console.ReadLine();
        }
    }
}

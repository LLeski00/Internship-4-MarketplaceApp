using MarketplaceApp.Data.Entities.Models;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Presentation.Actions.Home.Vendors
{
    public class DisplayProfitForPeriodAction : IAction
    {

        public string Name { get; set; } = "Display profit for a certain period";
        public Vendor Vendor { get; set; }
        public int MenuIndex { get; set; }

        public DisplayProfitForPeriodAction(Vendor vendor)
        {
            Vendor = vendor;
        }

        public void Open()
        {
            Writer.ConsoleClear();
            Console.WriteLine("Enter start date: ");

            if (!DateTime.TryParse(Console.ReadLine(), out var startDate)) {
                Writer.Error("Invalid date!");

                if (!Reader.DoYouWantToContinue())
                    Open();

                return;
            }

            Console.WriteLine("Enter end date: ");

            if (startDate > DateTime.Now) {
                Writer.Error("You can't enter a date in the future!");

                if (!Reader.DoYouWantToContinue())
                    Open();

                return;
            }

            if (!DateTime.TryParse(Console.ReadLine(), out var endDate))
            {
                Writer.Error("Invalid date!");

                if (!Reader.DoYouWantToContinue())
                    Open();

                return;
            }

            var profit = UserRepository.GetProfitForPeriod(Vendor, startDate, endDate);

            Console.WriteLine($"Your profit for period {startDate} - {endDate}: {profit} $");
            Console.ReadLine();
        }
    }
}

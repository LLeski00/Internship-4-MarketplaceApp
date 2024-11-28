using MarketplaceApp.Data.Entities.Models;
using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Actions.Home;
using MarketplaceApp.Presentation.Actions.Home.Vendors;
using MarketplaceApp.Presentation.Extensions;

namespace MarketplaceApp.Presentation.Factories
{
    public class VendorHomeFactory
    {
        public static IList<IAction> CreateActions(Vendor user)
        {
            var actions = new List<IAction>()
            {
                new ExitMenuAction(),
                new AddProductAction(user),
                new DisplayVendorsProductsAction(user),
                new DisplayVendorsSoldProductsAction(user),
                new DisplayProfitAction(user),
            };

            actions.SetActionIndexes();

            return actions;
        }
    }
}

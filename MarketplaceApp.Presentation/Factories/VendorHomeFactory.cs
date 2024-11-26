using MarketplaceApp.Data.Entities.Models;
using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Actions.Home;
using MarketplaceApp.Presentation.Extensions;

namespace MarketplaceApp.Presentation.Factories
{
    public class VendorHomeFactory
    {
        public static IList<IAction> CreateActions(User user)
        {
            var actions = new List<IAction>()
            {
                new ExitMenuAction(),
            };

            actions.SetActionIndexes();

            return actions;
        }
    }
}

using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Actions.Home.Products;
using MarketplaceApp.Presentation.Actions.Home;
using MarketplaceApp.Presentation.Extensions;
using MarketplaceApp.Data.Entities.Models;

namespace MarketplaceApp.Presentation.Factories
{
    public class CustomerHomeFactory
    {
        public static IList<IAction> CreateActions(User user)
        {
            var actions = new List<IAction>()
            {
                new ExitMenuAction(),
                new DisplayProductsAction(),
                new BuyProductAction(user),
            };

            actions.SetActionIndexes();
            
            return actions;
        }
    }
}

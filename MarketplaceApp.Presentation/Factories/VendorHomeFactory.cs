using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Actions.Home.Products;
using MarketplaceApp.Presentation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Presentation.Factories
{
    public class VendorHomeFactory
    {
        public static IList<IAction> CreateActions()
        {
            var actions = new List<IAction>()
            {
            };

            actions.SetActionIndexes();

            return actions;
        }
    }
}

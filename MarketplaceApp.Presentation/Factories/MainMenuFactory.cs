using Marketplace.Domain.Repositories;
using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Actions.MainMenu.Login;
using MarketplaceApp.Presentation.Actions.MainMenu.SignUp;
using MarketplaceApp.Presentation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Presentation.Factories
{
    public class MainMenuFactory
    {
        public static IList<IAction> CreateActions()
        {
            var actions = new List<IAction>
        {
            new LoginAction(),
            new SingUpAction(),
        };
            
            actions.SetActionIndexes();

            return actions;
        }
    }
}

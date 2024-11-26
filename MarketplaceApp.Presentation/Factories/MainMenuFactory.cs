using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Actions.MainMenu;
using MarketplaceApp.Presentation.Actions.MainMenu.Login;
using MarketplaceApp.Presentation.Actions.MainMenu.SignUp;
using MarketplaceApp.Presentation.Extensions;

namespace MarketplaceApp.Presentation.Factories
{
    public class MainMenuFactory
    {
        public static IList<IAction> CreateActions()
        {
            var actions = new List<IAction>()
            {
                new QuitAppAction(),
                new LoginAction(),
                new SingUpAction(),
            };
            
            actions.SetActionIndexes();

            return actions;
        }
    }
}

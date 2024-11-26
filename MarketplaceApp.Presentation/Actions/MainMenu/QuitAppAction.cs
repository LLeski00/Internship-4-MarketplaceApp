using MarketplaceApp.Data.Entities.Models;
using MarketplaceApp.Presentation.Abstractions;

namespace MarketplaceApp.Presentation.Actions.MainMenu
{
    public class QuitAppAction : IAction
    {
        public string Name { get; set; } = "Quit application";
        public int MenuIndex { get; set; }

        public void Open()
        {
            Environment.Exit(0);
        }
    }
}

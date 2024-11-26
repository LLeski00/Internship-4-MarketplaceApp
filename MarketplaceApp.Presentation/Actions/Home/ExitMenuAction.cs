using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Data.Entities.Models;

namespace MarketplaceApp.Presentation.Actions.Home
{
    public class ExitMenuAction : IAction
    {
        public string Name { get; set; } = "Exit menu";
        public int MenuIndex { get; set; }

        public void Open()
        {
        }
    }
}

using Marketplace.Data.Entities.Models;
using MarketplaceApp.Presentation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Presentation.Actions.MainMenu
{
    public class QuitAppAction : IAction
    {
        public string Name { get; set; } = "Quit application";
        public User? User { get; set; }
        public int MenuIndex { get; set; }

        public void Open()
        {
            Environment.Exit(0);
        }
    }
}

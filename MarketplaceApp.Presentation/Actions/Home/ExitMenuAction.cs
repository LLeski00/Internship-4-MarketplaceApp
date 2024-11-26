using Marketplace.Data.Entities.Enums;
using Marketplace.Data.Entities.Models;
using Marketplace.Domain.Repositories;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Presentation.Actions.Home
{
    public class ExitMenuAction : IAction
    {
        public string Name { get; set; } = "Exit menu";
        public User? User { get; set; }
        public int MenuIndex { get; set; }

        public void Open()
        {
        }
    }
}

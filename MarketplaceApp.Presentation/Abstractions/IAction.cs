using Marketplace.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Presentation.Abstractions
{
    public interface IAction
    {
        string Name { get; set; }

        int MenuIndex { get; set; }

        User? User { get; set; }

        void Open();
    }
}

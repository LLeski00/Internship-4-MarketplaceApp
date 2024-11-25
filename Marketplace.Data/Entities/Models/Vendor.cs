using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Data.Entities.Models
{
    public class Vendor : User
    {
        public double Profit { get; set; }
        public List<Product>? Products { get; set; }

        public Vendor(string firstName, string lastName, string email) : base(firstName, lastName, email)
        {
            Profit = 0.00;
            Products = null;
        }
    }
}

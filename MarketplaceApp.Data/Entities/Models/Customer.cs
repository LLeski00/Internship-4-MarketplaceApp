using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Data.Entities.Models
{
    public class Customer : User
    {
        public double Balance { get; set; }
        public List<Product>? PurchasedProducts { get; set; }
        public List<Product>? FavoriteProducts { get; set; }

        public Customer(string firstName, string lastName, string email) : base(firstName, lastName, email)
        {
            Balance = 100.00;
            PurchasedProducts = null;
            FavoriteProducts = null;
        }
    }
}

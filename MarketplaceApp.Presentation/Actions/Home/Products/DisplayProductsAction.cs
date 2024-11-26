using Marketplace.Data.Entities.Enums;
using Marketplace.Data.Entities.Models;
using Marketplace.Domain.Repositories;
using MarketplaceApp.Domain.Repositories;
using MarketplaceApp.Presentation.Abstractions;
using MarketplaceApp.Presentation.Extensions;
using MarketplaceApp.Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Presentation.Actions.Home.Products
{
    public class DisplayProductsAction : IAction
    {
        public string Name { get; set; } = "Display products";
        public User? User { get; set; }
        public int MenuIndex { get; set; }

        public void Open()
        {
            Writer.ConsoleClear();
            DisplayAllProducts();
            Console.ReadLine();
        }

        public void DisplayAllProducts()
        {
            foreach (var product in ProductRepository.GetAll().Where(i => i.Status == ProductStatus.OnSale))
            {
                DisplayProduct(product);
            }
        }

        public void DisplayProduct(Product product)
        {
            Console.WriteLine($"{product.Name}\n\tDescription: {product.Description}\n\tPrice: {product.Price} $\n\tID: {product.Id}\n\tCategory: {product.Category}\n\tAverage rating: {product.AverageRating}\n\tOwner: {product.Owner.FirstName} {product.Owner.LastName}");
        }

        public User? FindUser()
        {
            Console.Clear();
            if (!Reader.TryReadEmail("Enter your email: ", out string? email))
            {
                Writer.Error("Email invalid!");
                return null;
            }

            User? user = UserRepository.GetUser(email);
            return user;
        }
    }
}

namespace MarketplaceApp.Data.Entities.Models
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

        public Vendor(string firstName, string lastName, string email, List<Product>? products) : base(firstName, lastName, email)
        {
            Profit = 0.00;
            Products = null;
            Products = products;
        }
    }
}

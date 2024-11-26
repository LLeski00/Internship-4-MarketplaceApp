namespace MarketplaceApp.Data.Entities.Models
{
    public class Customer : User
    {
        public double Balance { get; set; }
        public List<Product>? PurchasedProducts { get; set; }
        public List<Product>? FavoriteProducts { get; set; }

        public Customer(string firstName, string lastName, string email, double balance) : base(firstName, lastName, email)
        {
            Balance = balance;
            PurchasedProducts = null;
            FavoriteProducts = null;
        }
    }
}

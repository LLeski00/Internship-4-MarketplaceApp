using MarketplaceApp.Data.Entities.Enums;

namespace MarketplaceApp.Data.Entities.Models
{
    public class Transaction
    {
        public Guid ProductId { get; set; }
        public Customer Customer { get; set; }
        public Vendor Vendor { get; set; }
        public DateTime DateOfPurchase { get; set; }

        public Transaction(Guid productId, Customer customer, Vendor vendor, DateTime dateOfPurchase)
        {
            ProductId = productId;
            Customer = customer;
            Vendor = vendor;
            DateOfPurchase = dateOfPurchase;
        }
    }
}

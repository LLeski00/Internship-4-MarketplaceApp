using MarketplaceApp.Data.Entities.Enums;

namespace MarketplaceApp.Data.Entities.Models
{
    public class Transaction
    {
        public Guid ProductId { get; set; }
        public Customer Customer { get; set; }
        public Vendor Vendor { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public double PricePaid { get; set; }

        public Transaction(Guid productId, Customer customer, Vendor vendor, DateTime dateOfPurchase, double pricePaid)
        {
            ProductId = productId;
            Customer = customer;
            Vendor = vendor;
            DateOfPurchase = dateOfPurchase;
            PricePaid = pricePaid;
        }
    }
}

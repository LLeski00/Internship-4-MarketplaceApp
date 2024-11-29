using MarketplaceApp.Data.Entities.Enums;

namespace MarketplaceApp.Data.Entities.Models
{
    public class Coupon
    {
        public string Code { get; set; }
        public double Discount { get; set; }
        public ProductCategory Category { get; set; }
        public DateTime ExpiryDate { get; set; }

        public Coupon(string code, double discount, ProductCategory category, DateTime expiryDate)
        {
            Code = code;
            Discount = discount;
            Category = category;
            ExpiryDate = expiryDate;
        }
    }
}

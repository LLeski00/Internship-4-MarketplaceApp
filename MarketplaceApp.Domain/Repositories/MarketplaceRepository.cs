using MarketplaceApp.Data.Entities.Enums;
using MarketplaceApp.Data.Entities.Models;
using MarketplaceApp.Domain.Enums;

namespace MarketplaceApp.Domain.Repositories
{
    public class MarketplaceRepository
    {
        public static ResponseResultType Buy(Customer user, Product product)
        {
            if (user.Balance < product.Price)
            {
                return ResponseResultType.InsufficientFunds;
            }

            user.Balance -= product.Price;
            product.Owner.Profit += product.Price;
            product.Status = ProductStatus.Sold;

            return ResponseResultType.Success;
        }
    }
}

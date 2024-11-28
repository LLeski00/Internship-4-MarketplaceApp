using MarketplaceApp.Domain.Enums;
using MarketplaceApp.Data.Entities.Models;
using static MarketplaceApp.Data.Marketplace;

namespace MarketplaceApp.Domain.Repositories
{
    public static class UserRepository
    {
        public static User? Get(User searchedUser)
        {
            foreach (var user in Context.Users)
            {
                if (user == searchedUser)
                    return user;
            }

            return null;
        }

        public static User? GetByEmail(string email)
        {
            foreach (var user in Context.Users)
            {
                if (email == user.Email)
                    return user;
            }

            return null;
        }

        public static ResponseResultType Add(User user)
        {
            Context.Users.Add(user);

            return ResponseResultType.Success;
        }
    }
}

using MarketplaceApp.Domain.Enums;
using MarketplaceApp.Data.Entities.Models;
using static MarketplaceApp.Data.Marketplace;

namespace MarketplaceApp.Domain.Repositories
{
    public static class UserRepository
    {
        public static User? GetUser(string email)
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

        

        /*public static ResponseResultType Update(User user, int id)
        {
            var userToUpdate = GetById(id);
            if (userToUpdate is null)
            {
                return ResponseResultType.NotFound;
            }

            userToUpdate.Email = user.Email;
            userToUpdate.Password = user.Password;

            return SaveChanges();
        }
        public static ResponseResultType Update(User user, int id, bool isAdmin)
        {
            var userToUpdate = GetById(id);
            if (userToUpdate is null)
            {
                return ResponseResultType.NotFound;
            }

            userToUpdate.Email = user.Email;
            userToUpdate.Password = user.Password;
            userToUpdate.IsAdmin = isAdmin;
            return SaveChanges();
        }*/
    }
}

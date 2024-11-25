using Marketplace.Data.Entities.Models;
using Marketplace.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarketplaceApp.Data.Marketplace;

namespace Marketplace.Domain.Repositories
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

        /*public static ResponseResultType Delete(int id)
        {
            var customerToDelete = GetById(id);
            if (customerToDelete is null)
            {
                return ResponseResultType.NotFound;
            }

            Context.Users.Remove(customerToDelete);

            return SaveChanges();
        }

        public static ResponseResultType Update(User user, int id)
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

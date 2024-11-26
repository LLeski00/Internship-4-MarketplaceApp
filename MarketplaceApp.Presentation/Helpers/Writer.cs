using Marketplace.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceApp.Presentation.Helpers
{
    public static class Writer
    {
        public static void Write(User user)
        {
            Console.WriteLine($"{user.Id}: {user.Email}");
        }

        public static void Write(ICollection<User> users)
        {
            foreach (var user in users)
                Write(user);
        }

        public static void Write(string output)
        {
            Console.WriteLine(output);
        }

        public static void Error(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(1000);
            Console.Clear();
        }

        public static void ConsoleClear()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine();
            }

            Console.Clear();
        }
    }
}

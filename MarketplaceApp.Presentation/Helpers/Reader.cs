using MarketplaceApp.Domain.Repositories;

namespace MarketplaceApp.Presentation.Helpers
{
    public static class Reader
    {
        public static bool TryReadNumber(out int number)
        {
            number = 0;
            var isNumber = int.TryParse(Console.ReadLine(), out var inputNumber);
            if (!isNumber)
                return false;

            number = inputNumber;
            return true;
        }

        public static bool TryReadNumber(string message, out int number)
        {
            Console.WriteLine(message);
            return TryReadNumber(out number);
        }

        public static bool TryReadName(out string name)
        {
            name = Console.ReadLine() ?? string.Empty;
            if (name == string.Empty || !name.All(char.IsLetter) || char.IsLower(name[0]))
                return false;

            return true;
        }

        public static bool TryReadName(string message, out string name)
        {
            Console.WriteLine(message);
            return TryReadName(out name);
        }

        public static bool TryReadEmail(out string? email)
        {
            email = Console.ReadLine();

            if (email == null || email == string.Empty || !email.Contains("@") || !email.Contains("."))
                return false;

            string[] inputSplitByMonkey = email.Split('@');

            if (inputSplitByMonkey.Length !=2 || inputSplitByMonkey[0].Length<1)
            {
                return false;
            }

            string[] inputSplitByTheDot = inputSplitByMonkey[1].Split(".");

            if (inputSplitByTheDot.Length != 2 || inputSplitByTheDot[0].Length < 3 || inputSplitByTheDot[1].Length < 2)
            {
                return false;
            }

            return true;
        }

        public static bool TryReadEmail(string message, out string? email)
        {
            Console.WriteLine(message);
            return TryReadEmail(out email);
        }

        public static bool TryReadProductCategory(out string? category)
        {
            category = Console.ReadLine();

            if (category == null || category == string.Empty)
                return false;

            foreach (var item in ProductRepository.GetProductCategories())
            {
                if (category.Equals(item.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    category = item.ToString();
                    return true;
                }
            }

            return false;
        }

        public static bool TryReadProductCategory(string message, out string? category)
        {
            Console.WriteLine(message);
            return TryReadProductCategory(out category);
        }

        public static bool DoYouWantToContinue()
        {
            Console.WriteLine("If you want to go back to previous page press y");
            var input = Console.ReadLine();
            if (input == "y")
                return false;
            return true;
        }
    }
}

namespace MarketplaceApp.Presentation.Helpers
{
    public static class Writer
    {
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

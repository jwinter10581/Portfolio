using System;

namespace MenuOfChampions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("  __  __  __  __  __  __  __  __  __  __  __  __  __  __  __  __");
            Console.WriteLine("  )(  )(  )(  )(  )(  )(  )(  )(  )(  )(  )(  )(  )(  )(  )(  )(");
            Console.WriteLine(" (__)(__)(__)(__)(__)(__)(__)(__)(__)(__)(__)(__)(__)(__)(__)(__)");
            Console.WriteLine("");
            Console.WriteLine("     Welcome to the alchemists' shoppe!");
            Console.WriteLine("     The items for sale today are...");
            // Console.WriteLine("");
            Console.WriteLine("  __  __  __  __  __  __  __  __  __  __  __  __  __  __  __  __");
            Console.WriteLine("  )(  )(  )(  )(  )(  )(  )(  )(  )(  )(  )(  )(  )(  )(  )(  )(");
            Console.WriteLine(" (__)(__)(__)(__)(__)(__)(__)(__)(__)(__)(__)(__)(__)(__)(__)(__)");
            Console.WriteLine("");

            string potionOne = "Healing Potion", potionTwo = "Invisibilty Potion", potionThree = "Stoneskin Potion";
            decimal priceOne = 50.00m, priceTwo = 149.99m, priceThree = 89.99m;

            Console.WriteLine("$ {0} *** {1}", priceOne, potionOne);
            Console.WriteLine("$ {0} ** {1}", priceTwo, potionTwo);
            Console.WriteLine("$ {0} *** {1}", priceThree, potionThree);
        }
    }
}

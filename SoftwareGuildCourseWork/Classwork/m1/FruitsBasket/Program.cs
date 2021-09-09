using System;

namespace FruitsBasket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fruit = {"Orange", "Apple", "Orange", "Apple", "Orange", "Apple",
            "Orange", "Apple", "Orange", "Orange", "Orange", "Apple", "Orange", "Orange",
            "Apple", "Orange", "Orange", "Apple", "Apple", "Orange", "Apple", "Apple",
            "Orange", "Orange", "Apple", "Apple", "Apple", "Banana", "Apple", "Orange",
            "Orange", "Apple", "Apple", "Orange", "Orange", "Orange", "Orange", "Apple",
            "Apple", "Apple", "Apple", "Orange", "Orange", "PawPaw", "Apple", "Orange",
            "Orange", "Apple", "Orange", "Orange", "Apple", "Apple", "Orange", "Orange",
            "Apple", "Orange", "Apple", "Kiwi", "Orange", "Apple", "Orange",
            "Dragonfruit", "Apple", "Orange", "Orange"};

            int numOranges = 0;
            int numApples = 0;
            int numOtherFruit = 0;

            for (int i = 0; i < fruit.Length; i++)
            {
                if (fruit[i] == "orange" || fruit[i] == "Orange")
                {
                    numOranges++;
                }
                else if (fruit[i] == "apple" || fruit[i] == "Apple")
                {
                    numApples++;
                }
                else
                {
                    numOtherFruit++;
                }
            }

            Console.WriteLine("Total # of fruit in basket: " + (numOranges + numApples + numOtherFruit));
            Console.WriteLine("Number of Apples: " + numApples);
            Console.WriteLine("Number of Oranges: " + numOranges);
            Console.WriteLine("Number of Other Fruit: " + numOtherFruit);
        }
    }
}

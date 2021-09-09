using System;

namespace DifferentKettleOfFish
{
    class Program
    {
        static void Main(string[] args)
        {
            int fish = 1;

            //while (fish <= 10)
            //{
            //    if (fish == 3)
            //    {
            //        Console.WriteLine("RED FISH!");
            //    }
            //    else if (fish == 4)
            //    {
            //        Console.WriteLine("BLUE FISH");
            //    }
            //    else
            //    {
            //        Console.WriteLine(fish + " fish!");
            //    }
            //fish++;

            for (int i = fish; i <= 10; i++)
            {
                if (i == 3)
                {
                    Console.WriteLine("RED FISH");
                }
                else if (i == 4)
                {
                    Console.WriteLine("BLUE FISH");
                }
                else
                {
                    Console.WriteLine(i + " fish!");
                }
            }
        }
    }
}

using System;

namespace PickyEater
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Looks like we have a picky eater on our hands...");
            Console.WriteLine("Lets see if this food will work.");

            Console.Write("How many times has it been fried? (#) ");
            int timesFried = Convert.ToInt32(Console.ReadLine());

            Console.Write("Does it have any spinach in it? (y/n) ");
            String hasSpinach = Console.ReadLine();

            Console.Write("Is it covered in cheese? (y/n) ");
            String cheeseCovered = Console.ReadLine();

            Console.Write("How many pats of butter are on top? (#) ");
            int butterPats = Convert.ToInt32(Console.ReadLine());

            Console.Write("Is it covered in chocolate? (y/n) ");
            String chocolatedCovered = Console.ReadLine();

            Console.Write("Does it have a funny name? (y/n) ");
            String funnyName = Console.ReadLine();

            Console.Write("Is it broccoli? (y/n) ");
            String isBroccoli = Console.ReadLine();

            if (hasSpinach.Equals("y") || funnyName.Equals("y"))
            {
                Console.WriteLine("There's no way he'll eat that!");
            }

            if (timesFried >= 2 && timesFried <= 4 && chocolatedCovered == "y")
            {
                Console.WriteLine("Oh, it's like deep-fried Snickers.  That'll be a hit!");
            }

            if (timesFried == 2 && cheeseCovered == "y")
            {
                Console.WriteLine("Mmm.  Yeah, he'll eat fried cheesey doodles.");
            }

            if (isBroccoli == "y" && butterPats >= 6 && cheeseCovered == "y")
            {
                Console.WriteLine("As lopng as the green is hidden by cheddar, it'll happen!");
            }

            else if (isBroccoli == "y")
            {
                Console.WriteLine("Oh, green stuff like that might as well go in the bin.");
            }
        }
    }
}

using System;

namespace SpaceRustlers
{
    class Program
    {
        static void Main(string[] args)
        {
            int spaceships = 10, aliens = 25, cows = 100;

            /* Else if is used to provide a secondary condition for each condition.  You can use them
            to catch and branch off into another scenario if a certain criteria is met. */
            /*  If you removed the else from else if it would start a new set of statements.  Each
            else if pairs up with a if statement to provide alternate conditions */

            if (aliens >= spaceships)
            {
                Console.WriteLine("Vroom, vroom! Let's get going!");
            }

            else
            {
                Console.WriteLine("There aren't enough green guyls to drive these ships!");
            }

            if (cows == spaceships)
            {
                Console.WriteLine("Wow, way to plan ahead! Just enough room for all these walking hamburgers!");
            }

            else if (cows > spaceships)
            {
                Console.WriteLine("Dangit! I don't know how we're going to fit all these cows in here!");
            }

            else
            {
                Console.WriteLine("Too many ships, and not enough cows.");
            }

            if (aliens > cows)
            {
                Console.WriteLine("Hurrah, we've got the grub! Hamburger party on Alpha Centauri!");
            }

            else if (aliens < cows)
            {
                Console.WriteLine("Oh no! The herds got restless and took over!  Looks like we're hamburger now!!");
            }

            else
            {
                Console.WriteLine("We have just enough for a small hamburger gathering, adequate.");
            }


        }
    }
}

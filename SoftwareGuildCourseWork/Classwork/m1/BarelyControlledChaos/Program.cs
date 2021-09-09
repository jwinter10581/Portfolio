using System;

namespace BarelyControlledChaos
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            string color = RandomColor(rng.Next(5));
            string animal = RandomAnimal(rng.Next(5));
            string colorAgain = RandomColor(rng.Next(5));
            int weight = RandomNumber(rng.Next(5, 200), rng.Next(5, 200));
            int distance = RandomNumber(rng.Next(10, 20), rng.Next(10, 20));
            int number = RandomNumber(rng.Next(10000, 20000), rng.Next(10000, 20000));
            int time = RandomNumber(rng.Next(2, 6), rng.Next(2, 6));


            Console.WriteLine("Once, when I was very small...");
            Console.WriteLine($"I was chased by a {color}, {weight}lb miniature {animal} for over {distance} miles!!");
            Console.WriteLine($"I had to hide in a field of over {number} {colorAgain} poppies for nearly {time} hours until it left me alone!");
            Console.WriteLine("\nIt was QUITE the experience, let me tell you!");
        }

        static public string RandomColor(int c)
        {
            switch (c)
            {
                case 0:
                    return "red";
                case 1:
                    return "orange";
                case 2:
                    return "yellow";
                case 3:
                    return "green";
                case 4:
                    return "blue";
                default:
                    return "Absence of Color";
            }
        }

        static public string RandomAnimal(int a)
        {
            switch (a)
            {
                case 0:
                    return "bees";
                case 1:
                    return "ducks";
                case 2:
                    return "frogs";
                case 3:
                    return "snakes";
                case 4:
                    return "quokka";
                default:
                    return "Absence of Animal";
            }
        }

        static public int RandomNumber(int o, int t)
        {
            Random rng2 = new Random();
            int number = 0;

            if (o < t)
            {
                number = rng2.Next(o, t);
                return number;
            }

            else if (t < o)
            {
                number = rng2.Next(t, o);
                return number;
            }

            else
            {
                return o;
            }
        }
    }
}

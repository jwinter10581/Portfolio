using System;

namespace BewareTheKraken
{
    class Program
    {
        static void Main(string[] args)
        {
            int depthDivedInFt = 0;
            string stopNow = "n";
            Random rng = new Random();
            int fishies;


            Console.WriteLine("Alrighty!  Get those flippers and wetsuits on - We're going diving!!");
            Console.WriteLine("Here we goooOOOoooOOO... *SPLASH*");

            // Turns out the ocean is only so deep, 36200 at the deepest survey
            // so if we reach the bottom... We should probably stop.

            while (depthDivedInFt < 36200)
            {
                Console.WriteLine($"So far, we've descended {depthDivedInFt} feet.");

                if (depthDivedInFt >= 20000)
                {
                    Console.WriteLine("Uhh, I think I see a Kraken guys...");
                    Console.WriteLine("TIME TO GOOOOOOOOOO!");
                    break;
                }

                depthDivedInFt += 1000;
                fishies = rng.Next(1, 11);

                switch (fishies)
                {
                    case 1:
                        Console.WriteLine("You spot a flounder!");
                        break;
                    case 2:
                        Console.WriteLine("Wow is that crab swimming?");
                        break;
                    case 3:
                        Console.WriteLine("Woah look at that tuna!");
                        break;
                    case 4:
                        Console.WriteLine("Yummy salmon!");
                        break;
                    case 5:
                        Console.WriteLine("Is that a coelacanth?!");
                        break;
                    case 6:
                        Console.WriteLine("That eel looks so slippery!?");
                        break;
                    case 7:
                        Console.WriteLine("Oooh spiky puffer fish.");
                        break;
                    case 8:
                        Console.WriteLine("Hey, a orange roughy! Delicious!");
                        break;
                    case 9:
                        Console.WriteLine("Baby shark doo doo doot.");
                        break;
                    case 10:
                        Console.WriteLine("Creepy anglerfish, yuck!");
                        break;
                }

                Console.WriteLine("Would you like to stop now? (y/n) ");
                stopNow = Console.ReadLine();

                if (stopNow == "y")
                {
                    Console.WriteLine("Okay okay... Let's swim back up.");
                    break;
                }
            }
            Console.WriteLine("");
            Console.WriteLine($"We ended up going {depthDivedInFt} feet down.");
            Console.WriteLine("I bet we can do better next time!");
        }
    }
}

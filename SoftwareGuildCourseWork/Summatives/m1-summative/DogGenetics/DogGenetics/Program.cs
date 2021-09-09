<<<<<<< Updated upstream
﻿using System;

namespace DogGenetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Dog Genetics generator!");
            Console.WriteLine("With just a name, we can determine your dogs background.");
            Console.Write("What is your dog's name? ");
            string dogName = Console.ReadLine();

            Console.WriteLine($"Well then, I have this highly reliable report on {dogName}'s" +
                $" prestigious background right here.");

            Console.WriteLine($"{dogName} is:");

            Random rng = new Random();

            double breedOne, breedTwo, breedThree,breedFour, breedFive, breedSum;

            breedOne = rng.NextDouble();
            breedTwo = rng.NextDouble();
            breedThree = rng.NextDouble();
            breedFour = rng.NextDouble();
            breedFive = rng.NextDouble();

            breedSum = (breedOne + breedTwo + breedThree + breedFour + breedFive);

            breedOne = breedOne / breedSum;
            breedTwo = breedTwo / breedSum;
            breedThree = breedThree / breedSum;
            breedFour = breedFour / breedSum;
            breedFive = breedFive / breedSum;

            // {0:P} gives two whole and two decimal places
            // {0:00%} gives just two whole number places
            // I think {0:P} is more accurate in case there is a rounding issue.

            Console.WriteLine($"{breedOne:P} Bernese Mountain Dog");
            Console.WriteLine($"{breedTwo:P} Shiba Inu");
            Console.WriteLine($"{breedThree:P} Minitature Dachshund");
            Console.WriteLine($"{breedFour:P} Gret Pyreness");
            Console.WriteLine($"{breedFive:P} Irish Water Spaniel");
            Console.WriteLine("\nWow, that's QUITE the dog!!");
        }
    }
}
=======
﻿using System;

namespace DogGenetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Dog Genetics generator!");
            Console.WriteLine("With just a name, we can determine your dogs background.");
            Console.Write("What is your dog's name? ");
            string dogName = Console.ReadLine();

            Console.WriteLine($"Well then, I have this highly reliable report on {dogName}'s" +
                $" prestigious background right here.");

            Console.WriteLine($"{dogName} is:");

            Random rng = new Random();

            double breedOne, breedTwo, breedThree,breedFour, breedFive, breedSum;

            breedOne = rng.NextDouble();
            breedTwo = rng.NextDouble();
            breedThree = rng.NextDouble();
            breedFour = rng.NextDouble();
            breedFive = rng.NextDouble();

            breedSum = (breedOne + breedTwo + breedThree + breedFour + breedFive);

            breedOne = breedOne / breedSum;
            breedTwo = breedTwo / breedSum;
            breedThree = breedThree / breedSum;
            breedFour = breedFour / breedSum;
            breedFive = breedFive / breedSum;

            // {0:P} gives two whole and two decimal places
            // {0:00%} gives just two whole number places
            // I think {0:P} is more accurate in case there is a rounding issue.

            Console.WriteLine($"{breedOne:P} Bernese Mountain Dog");
            Console.WriteLine($"{breedTwo:P} Shiba Inu");
            Console.WriteLine($"{breedThree:P} Minitature Dachshund");
            Console.WriteLine($"{breedFour:P} Gret Pyreness");
            Console.WriteLine($"{breedFive:P} Irish Water Spaniel");
            Console.WriteLine("\nWow, that's QUITE the dog!!");
        }
    }
}
>>>>>>> Stashed changes

using System;

namespace ALittleChaos
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomizer = new Random();

            Console.WriteLine("Random's can make integers: " + randomizer.Next());
            Console.WriteLine("Or a double: " + randomizer.NextDouble());

            int num = randomizer.Next(101); // If you change this to Next(51) + 50, it will generate a number between 1-50 and add 50

            Console.WriteLine("You can store a randomized result: " + num);
            Console.WriteLine("And use it over and over again: " + num + ", " + num);

            Console.WriteLine("Or just keep generating new values");
            Console.WriteLine("Here's a bunch of numbers from 0 - 100: ");

            Console.Write(randomizer.Next(101) + ", ");
            Console.Write(randomizer.Next(101) + ", ");
            Console.Write(randomizer.Next(101) + ", ");
            Console.Write(randomizer.Next(101) + ", ");
            Console.Write(randomizer.Next(101) + ", ");
            Console.WriteLine(randomizer.Next(101));

            int mathNumOne, mathNumTwo;

            mathNumOne = randomizer.Next(101);
            mathNumTwo = randomizer.Next(101);

            Console.WriteLine($"The sum of {mathNumOne} and {mathNumTwo} is " + (mathNumOne + mathNumTwo));
        }
    }
}

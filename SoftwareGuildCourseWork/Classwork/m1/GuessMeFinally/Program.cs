using System;

namespace GuessMeFinally
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();

            int correctAnswer = rng.Next(-100, 101);
            int userGuess, guessCounter = 0;

            Console.WriteLine("Hey there, we're gonna play a guessing game!");
            Console.WriteLine("I'll think of a number and you try to guess it.");
            Console.WriteLine("Let's shoot for something between -100 & 100.");
            Console.Write("Your guess: ");

            while (true)
            {
                userGuess = Convert.ToInt32(Console.ReadLine());
                guessCounter++;

                if (userGuess == correctAnswer && guessCounter == 0)
                {
                    Console.WriteLine("Lucky guess, you got it on the first try!");
                }

                else if (userGuess == correctAnswer)
                {
                    Console.WriteLine("There it is, that's the one!");
                }

                else if (userGuess < correctAnswer)
                {
                    Console.WriteLine($"{userGuess} is too low, try again.");
                }

                else if (userGuess > correctAnswer)
                {
                    Console.WriteLine($"{userGuess} is way too high, give it another shot.");
                }
            }
    }
}

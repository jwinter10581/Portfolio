using System;

namespace GuessMe
{
    class Program
    {
        static void Main(string[] args)
        {
            int correctAnswer = 42, userGuess;

            Console.WriteLine("Hey there, we're gonna play a guessing game!");
            Console.WriteLine("I'll think of a number and you try to guess it.");
            Console.WriteLine("Let's shoot for something between 1-100.");
            Console.Write("Your guess: ");
            userGuess = Convert.ToInt32(Console.ReadLine());

            if (userGuess == correctAnswer)
            {
                Console.WriteLine("Lucky guess, you got it!");
            }

            else if (userGuess < correctAnswer)
            {
                Console.WriteLine($"{userGuess} is too low, it's actually {correctAnswer}.");
            }

            else if (userGuess > correctAnswer)
            {
                Console.WriteLine($"{userGuess} is way too high, the number is {correctAnswer}.");
            }
        }
    }
}

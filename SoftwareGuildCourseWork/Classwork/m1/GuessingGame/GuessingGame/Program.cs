using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int theAnswer, lowRange = 1, highRange = 0, guessCounter = 0, playerGuess;
            string playerInput;
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Welcome to the guessing game!  What is your name? ");
            string name = Console.ReadLine();
            Console.Write($"\nThanks {name}, would you like to play on easy (1-5), normal (1-20), or hard (1-50)? ");
            string difficulty = Console.ReadLine();

            while (true)
            {
                if (difficulty == "easy")
                {
                    highRange = 5;
                    break;
                }
                else if (difficulty == "normal")
                {
                    highRange = 20;
                    break;
                }
                else if (difficulty == "hard")
                {
                    highRange = 50;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\nPlease enter easy, normal, or hard: ");
                    difficulty = Console.ReadLine();
                }
            }

            Random r = new Random();
            theAnswer = r.Next(lowRange, highRange+1);
            Console.ForegroundColor = ConsoleColor.White;

            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Enter your guess, {name}. Choose between {lowRange}-{highRange}: ");
                playerInput = Console.ReadLine();

                if (playerInput == "Q")
                {
                    break;
                }
                while (true)
                {
                    bool value = int.TryParse(playerInput, out playerGuess);

                    if (!value)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"\nThat is not a valid input, please enter a number between {lowRange}-{highRange}: ");
                        playerInput = Console.ReadLine();
                    }
                    else if (playerGuess < lowRange)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"\nThat number was lower than the minimum, please enter a valid input between {lowRange}-{highRange}: ");
                        playerInput = Console.ReadLine();
                    }
                    else if (playerGuess > highRange)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"\nThat number was higher than the maximum, please enter a valid input between {lowRange}-{highRange}: ");
                        playerInput = Console.ReadLine();
                    }
                    else
                    {
                        break;
                    }
                }
                guessCounter++;

                if (playerGuess == theAnswer && guessCounter == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{theAnswer} was the number!! YOU MUST BE A PSYCHIC, {name}!");
                    break;
                }
                else if (playerGuess == theAnswer)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{theAnswer} was the number.  You Win! Great job {name}!");
                    break;
                }
                else if (playerGuess > theAnswer)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; // I wasn't sure if this was an error (red) or just playing the game (white) ... So I went with yellow.
                    Console.WriteLine($"Your guess was too high, {name}!");
                }
                else if (playerGuess < theAnswer)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; // I wasn't sure if this was an error (red) or just playing the game (white) ... So I went with yellow.
                    Console.WriteLine($"Your guess was too low, {name}!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"That wasn't a number!  You silly goose, {name}");
                }

            } while (true);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"It took you {guessCounter} to get it.");
            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }
    }
}

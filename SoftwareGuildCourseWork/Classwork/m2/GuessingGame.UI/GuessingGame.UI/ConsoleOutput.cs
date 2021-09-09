using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuessingGame.BLL;

namespace GuessingGame.UI
{
    public class ConsoleOutput
    {
        // Best practice: Use helper function to avoid duplicate code.

        // <summary>
        // PressKeyToContinue - display prompt and wait for Console key input
        // </summary>
        // <param name="prompt">Message to display for prompt. If none specified, display
        // default "Press any key to continue...". Uses C# optional parameter with default value</param>

        public static void PressKeyToContinue(string prompt = "Press any key to continue...")
        {
            Console.WriteLine(prompt);
            Console.ReadKey();
        }

        public static void DisplayTitle()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Better, Testable, Guessing game!\n\n");
            PressKeyToContinue("Press any key to start the game...");
        }

        public static void DisplayGuessMessage(GuessResult result)
        {
            string message = string.Empty;

            switch (result)
            {
                case GuessResult.Invalid:
                    // Since this message includes the valid range, get the range form the manager
                    message = $"That guess wasn't valid, try something between {GameManager.MinimumGuess} and {GameManager.MaximumGuess}.";
                    break;
                case GuessResult.Higher:
                    message = "Your guess was too low, try something higher.";
                    break;
                case GuessResult.Lower:
                    message = "Your guess was too high, try something lower.";
                    break;
                case GuessResult.Victory:
                    message = "You did it! You are awesome!";
                    break;
            }

            Console.WriteLine(message);
            PressKeyToContinue(); // Parameter not specified and uses default value
        }
    }
}

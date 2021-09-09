using System;

namespace TriviaNight
{
    class Program
    {
        static void Main(string[] args)
        {
            int userScore = 0, userInput;

            Console.WriteLine("It's TRIVIA NIGHT!! *air horn noises*  ARE YOU READY!?");
            Console.WriteLine("First Question!");
            Console.WriteLine("What Pokemon has electricity-storing pouches on its cheeks?");
            Console.WriteLine("1) Jigglypuff    2) Pikachu");
            Console.WriteLine("3) Squirtle      4) Gengar");
            Console.WriteLine("");
            Console.Write("Your Answer: ");
            userInput = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");

            if (userInput == 2)
            {
                userScore++;
                Console.WriteLine($"You did it, that's correct!");
            }
            else
            {
                Console.WriteLine("Ooh I'm sorry, the correct answer was 2) Pikachu");
            }

            Console.WriteLine($"You currently have {userScore} point(s).");
            Console.WriteLine("");
            Console.WriteLine("Second Question");
            Console.WriteLine("As of the latest generation of pokemon, how many types are there?");
            Console.WriteLine("1) Twelve      2) Fifteen");
            Console.WriteLine("3) Eighteen    4) Twenty");
            Console.WriteLine("");
            Console.Write("Your Answer: ");
            userInput = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");

            if (userInput == 3)
            {
                userScore++;
                Console.WriteLine($"Very nice! That's correct!");
            }
            else
            {
                Console.WriteLine("It's actually 3) Eighteen.  Better luck next time!");
            }

            Console.WriteLine($"You currently have {userScore} point(s).");
            Console.WriteLine("");
            Console.WriteLine("Third Question");
            Console.WriteLine("Currently, which is the tallest Pokemon?");
            Console.WriteLine("1) Eternatus    2) Wailord");
            Console.WriteLine("3) Steelix      4) Rayquaza");
            Console.WriteLine("");
            Console.Write("Your Answer: ");
            userInput = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");

            if (userInput == 1)
            {
                userScore++;
                Console.WriteLine("Hey, you got it right!");
            }
            else
            {
                Console.WriteLine("Ooh tricky one, the answer is 1) Eternatus.");
            }

            Console.WriteLine($"That's the game!  You got {userScore} point(s) out of 3.");
            Console.WriteLine("Thank you for playing!");
        }
    }
}

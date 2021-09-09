using System;

namespace ForTimesFor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hey there, do you like times tables? I do!");
            Console.Write("What number would you like to recite for me? ");
            int numberRequested = Convert.ToInt32(Console.ReadLine());
            int userAnswer, score = 0;

            for (int i = 1; i <= 15; i++)
            {
                Console.Write("What is " + i + " * " + numberRequested + " = ");
                userAnswer = Convert.ToInt32(Console.ReadLine());

                if (userAnswer == (i * numberRequested))
                {
                    Console.WriteLine("That's correct!");
                    score++;
                }

                else
                {
                    Console.WriteLine("That's incorrect, the correct answer is " + (i * numberRequested));
                }
            }

            if (score > (15 * .9))
            {
                Console.WriteLine("Good job! You really know your times tables! Congrats on being a mathlete");
            }
            else if (score < (15 * .5))
            {
                Console.WriteLine("You really should study more, multiplication tables are great.");
            }
            else
            {
                Console.WriteLine("You did okay. Thank you for playing, goodbye!");
            }
        }
    }
}

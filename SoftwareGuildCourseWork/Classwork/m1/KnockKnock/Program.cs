using System;

namespace KnockKnock
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Knock Knock! Guess who!! ");
            String userGuess = Console.ReadLine();

            if (userGuess.Equals("Voldemort"))
            {
                Console.WriteLine("Hey! That's right! I'm back!");
                Console.WriteLine("Thanks for saying my name.");
            }
            else
            {
                Console.WriteLine($"Dude, do I -look- like {userGuess}?");
            }
        }
    }
}

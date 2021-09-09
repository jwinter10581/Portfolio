using System;

namespace PassingTheTuringTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName, userColor, userSpice;
            int userNumber;

            Console.WriteLine("Hello there!");
            Console.WriteLine("What is your name? ");
            userName = Console.ReadLine();

            Console.WriteLine($"Hey {userName}, I'm Robo-Jon.  Nice to meet you!");
            Console.WriteLine("What is your favorite color? ");
            userColor = Console.ReadLine();

            Console.WriteLine($"Wow, {userColor}?  Mine's saffron!");
            Console.WriteLine("I really love saffron, it's super fun to cook with.");
            Console.WriteLine($"Do you have a favorite spice, {userName}? ");
            userSpice = Console.ReadLine();

            Console.WriteLine($"Well hey, {userSpice} isn't my favorite, but you do you.");
            Console.WriteLine("Speaking of favorites, what is your favorite integer? ");
            userNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"{userNumber} is pretty solid, but mine is 42 for a plethora of reasons.");
            Console.WriteLine($"Did you know that {userNumber} * 42 is " + (userNumber * 42) + "? That's the best number.");

            Console.WriteLine($"Well, thanks for chatting with me {userName}! I had a blast!");
        }
    }
}

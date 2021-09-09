using System;

namespace QuestForTheUserInput
{
    class Program
    {
        static void Main(string[] args)
        {
            string yourName;
            string yourQuest;
            double velocityOfSwallow;

            // We can use Console.Readline to assign value to our strings
            // because its default is string

            Console.WriteLine("What is your name? ");
            yourName = Console.ReadLine();

            Console.WriteLine("What is your quest? ");
            yourQuest = Console.ReadLine();

            /* when we get to our double data type, we have to do a bit of type changing
               so we'll use Convert.ToDouble method and put Console.Readline() as the argument.
            */

            Console.WriteLine("What is the airspeed velocity of an unladen swallow? ");
            velocityOfSwallow = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine($"How do you know {velocityOfSwallow} is correct {yourName}?");
            Console.WriteLine("You didn't even know if the swallow was African or European!");
            Console.WriteLine($"Maybe skip answering things about birds and instead go {yourQuest}.");

        }
    }
}

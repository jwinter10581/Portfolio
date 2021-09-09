using System;

namespace AllAboutMe
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Jonathan Winter";
            string food = "fresh sushi";
            int pets = 0;
            string livingSpace = "apartment";
            bool whistle = true;

            Console.WriteLine("My name is {0}", name);
            Console.WriteLine("My favorite food is {0}", food);
            Console.WriteLine("I have {0} pets.", pets);
            Console.WriteLine("I live in a {0}, and it's okay.", livingSpace);
            Console.WriteLine("It is {0} that I know how to whistle.", whistle);
        }
    }
}

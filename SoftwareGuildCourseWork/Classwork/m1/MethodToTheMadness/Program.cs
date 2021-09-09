using System;

namespace MethodToTheMadness
{
    class Program
    {
        static void Main(string[] args)
        {
            EatMe();
            DrinkMe();

            Console.WriteLine("\n- Lewis Caroll, Alice in Wonderland");

        }

        static void EatMe()
        {
            Console.WriteLine("'But I don't want to go among mad people,' Alice remarked.");
            Console.WriteLine("'Oh, you can't help that,' said the Cat.");
            Console.WriteLine("'We're all mad here.  I'm mad.  You're mad.'");
        }

        static void DrinkMe()
        {
            Console.WriteLine("'How do you know I'm mad?' said Alice.");
            Console.WriteLine("'You must be,' said the Cat, "
                + "' or you wouldn't have come here.'");

        }
    }
}

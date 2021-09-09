using System;

namespace AllTheTrivia
{
    class Program
    {
        static void Main(string[] args)
        {
            string lotrAnswer, boardGameAnswer, pixarAnswer;
            int mathAnswer, godzillaAnswer;

            Console.WriteLine("What creature did Gandalf say could not pass? ");
            lotrAnswer = Console.ReadLine();

            Console.WriteLine("What is the number one ranked game on board game geek? ");
            boardGameAnswer = Console.ReadLine();

            Console.WriteLine("What is the only even prime number? ");
            mathAnswer = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What year did Godzilla premiere? ");
            godzillaAnswer = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What movie is Pixar's only prequel? ");
            pixarAnswer = Console.ReadLine();

            Console.WriteLine("");

            Console.WriteLine($"Gandalf said that {boardGameAnswer} could not pass!");
            Console.WriteLine($"Board game geek's best game is {pixarAnswer}.");
            Console.WriteLine($"It's crazy how numbers work, the prime number is {godzillaAnswer}.");
            Console.WriteLine($"Godzilla originally came out in the year {mathAnswer}.");
            Console.WriteLine($"Pixar's only made one prequel and it was {lotrAnswer}!");
        }
    }
}

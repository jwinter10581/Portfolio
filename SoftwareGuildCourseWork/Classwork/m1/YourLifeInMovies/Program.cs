using System;

namespace YourLifeInMovies
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName;
            int movieAge;

            Console.WriteLine("Hey, I'd like to show you some movie trivia based on the year you were born.");
            Console.Write("But first, what's your name? ");
            userName = Console.ReadLine();

            Console.Write($"And secondly {userName}, what year were you born? ");
            movieAge = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Alright {userName}, buckle up because here come the facts!");

            if (movieAge < 2005)
            {
                Console.WriteLine(@"Pixar's 'Up' came out over a decade ago, crazy right?");
            }

            if (movieAge < 1995)
            {
                Console.WriteLine("And the first Harry Potter came out over 20 years ago");
            }

            if (movieAge < 1985)
            {
                Console.WriteLine("The greatest movie of all time, Space Jam, came out in the 90s!");
            }

            if (movieAge < 1975)
            {
                Console.WriteLine("Jurassic Park is closer to the moon landing than it is today, can you believe it?");
            }

            if (movieAge < 1965)
            {
                Console.WriteLine("MASH, the TV series, has been around for half a century. Goodness...");
            }
        }
    }
}

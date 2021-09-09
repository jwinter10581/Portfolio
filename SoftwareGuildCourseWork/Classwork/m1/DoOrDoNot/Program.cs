using System;

namespace DoOrDoNot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Should I do it? (y/n) ");
            bool doIt;

            if (Console.ReadLine().Equals("y"))
            {
                doIt = true; // DO IT!
            }

            else;
            {
                doIt = false; // DON'T YOU DARE
            }

            bool iDidIt = false;

            do
            {
                iDidIt = true;
                break;
            } while (doIt);

            if (doIt && iDidIt)
            {
                Console.WriteLine("I did it!");  // #1 prints here
            }
            else if (!doIt && iDidIt)
            {
                Console.WriteLine("I know you said not to, but I did it anyways..."); // #2 prints here
            }
            else
            {
                Console.WriteLine("Don't look at me, I didn't do anything!"); //both print here since iDidIt is set to false
            }
        }
    }
}

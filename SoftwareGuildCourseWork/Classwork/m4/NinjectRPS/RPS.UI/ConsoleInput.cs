using RPS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.UI
{
    public class ConsoleInput
    {
        public static Choice GetChoiceFromUser()
        {
            string input;

            while(true)
            {
                Console.Write("Enter your choice (R)ock, (P)aper, or (S)cissors: ");
                input = Console.ReadLine();

                switch(input.ToUpper())
                {
                    case "R":
                        return Choice.Rock;
                    case "P":
                        return Choice.Paper;
                    case "S":
                        return Choice.Scissors;
                }

                Console.WriteLine("That was not a valid choice! Try R, P, or S!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        public static bool QueryPlayAgain()
        {
            string input;

            while (true)
            {
                Console.Write("Play again? (Y/N): ");
                input = Console.ReadLine();

                switch (input.ToUpper())
                {
                    case "Y":
                        return true;
                }

                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPS.BLL;

namespace RPS.UI
{
    public class ConsoleOutput
    {
        public static void DisplayResult(PlayRoundResponse response)
        {
            Console.WriteLine($"You picked {GetEnumName(response.Player1Choice)}, they picked {GetEnumName(response.Player2Choice)}...");
            PrintResultText(response.Player1Result);
        }

        private static void PrintResultText(GameResult player1Result)
        {
            switch(player1Result)
            {
                case GameResult.Win:
                    Console.WriteLine("You win!");
                    break;
                case GameResult.Loss:
                    Console.WriteLine("You lose!");
                    break;
                default:
                    Console.WriteLine("It's a draw!");
                    break;
            }
        }

        private static string GetEnumName(Choice choice)
        {
            return Enum.GetName(typeof(Choice), choice);
        }
    }
}

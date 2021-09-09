using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Menu;
using BattleShip.BLL.Players;

namespace BattleShip.UI
{
    public class Menu
    {
        public void ClearScreen() // helper method
        {
            Console.ReadKey();
            Console.Clear();
        }
        public void WelcomeScreen()
        {
            Console.WriteLine("                           Welcome to Battleship!");
            Console.WriteLine(@"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~oo~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                                    o o
                                    o ooo
                                    o oo
                                        o o    |   #)
                                        oo    _|_|_#_    
                                            o| 117   |
     __                   ___________________|       |__________________
    |   -_______-----------                                             \
    >|    _____                                                   --->   )
    |__ -     ---------_________________________________________________/");

            Console.WriteLine("\nPress any key to continue");
            ClearScreen();
        }

        public void PlayerIntroduction()
        {
            Console.WriteLine("Welcome to Battleship player!  Today we will be playing a normal game of Battleship.");
            Console.WriteLine("You will need a human opponent to play.  You will take turns placing five ships on your own 10x10 board.");
            Console.WriteLine("Then, you will fire shots at the opponents board.  Once either of you has hit and sunk all of the others ships, a winner will be declared!");
            Console.WriteLine("Lets begin by getting your name, and by setting your ships up.");
            ClearScreen();
        }

        public void PlayerSetUp()
        {
            GameSetup game = new GameSetup();
            Player playerOne = new Player();

            Console.Write($"Player 1, please enter your name: ");
            playerOne = game.CreateNewPlayer();
            playerOne.playerID = 1;
        }
    }
}

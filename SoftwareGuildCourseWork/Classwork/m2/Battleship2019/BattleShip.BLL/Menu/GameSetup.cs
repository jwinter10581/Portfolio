using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Players;

namespace BattleShip.BLL.Menu
{
    public class GameSetup
    {
        public Player CreateNewPlayer()
        {
            PlayerTurn dice = new PlayerTurn();
            Player player = new Player();
            player.Name = Console.ReadLine();

            while (player.Name == "")
            {
                Console.WriteLine("That was not a valid input, please enter a name.");
                player.Name = Console.ReadLine();
            }

            player.initiative = dice.RollInitiative(player);

            return player;
        }    
    }
}

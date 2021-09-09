using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.BLL.Players
{
    public class PlayerTurn
    {
        static Random rng = new Random();

        public int RollInitiative(Player player)
        {
            player.initiative = rng.Next();

            return player.initiative;
        }

        public bool CompareInitiative(Player playerOne, Player playerTwo)
        {
            if (playerOne.initiative >= playerTwo.initiative) // for simplicity sake, although if they do roll the same it might make sense to roll again in a real world scenario
            {
                playerOne.first = true;
                return playerOne.first;
            }
            else
            {
                playerTwo.first = true;
                return playerTwo.first;
            }
        }
    }
}

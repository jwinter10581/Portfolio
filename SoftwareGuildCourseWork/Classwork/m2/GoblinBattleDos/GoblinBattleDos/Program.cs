using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoblinBattleDos
{
    class Program
    {
        static void Main(string[] args)
        {
            Goblin goblinPlayer = new Goblin();
            Goblin goblinEnemy = new Goblin();

            //goblinPlayer.SetName("Jon");
            //goblinPlayer.SetHitPoints(10);
            goblinPlayer.Name = "Jon";
            goblinPlayer.HitPoints = 10;

            //goblinOther.SetName("Urdnot");
            //goblinOther.SetHitPoints(10);
            goblinEnemy.Name = "Urdnot";
            goblinEnemy.HitPoints = 10;

            while (!goblinPlayer.IsDead && !goblinEnemy.IsDead)
            {
                goblinPlayer.Attack(goblinEnemy);

                Goblin goblinTemp = goblinPlayer;  // swap position to attack back
                goblinPlayer = goblinEnemy;
                goblinEnemy = goblinTemp;
                Console.WriteLine("~");
            }

            Console.WriteLine("The battle is ended!");
            Console.ReadLine();
        }
    }
}

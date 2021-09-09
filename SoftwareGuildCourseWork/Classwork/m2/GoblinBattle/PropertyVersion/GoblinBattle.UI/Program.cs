using System;

namespace GoblinBattle.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Goblin goblinPlayer = new Goblin();
            Goblin goblinOther = new Goblin();

            goblinPlayer.HitPoints = 10;
            goblinPlayer.Name = "Bob";

            goblinOther.HitPoints = 10;
            goblinOther.Name = "Tom";

            while (!goblinPlayer.IsDead && !goblinOther.IsDead)
            {
                goblinPlayer.Attack(goblinOther);
                // swap players
                Goblin goblinTemp = goblinPlayer;
                goblinPlayer = goblinOther;
                goblinOther = goblinTemp;
            }

            Console.WriteLine("The battle is ended!");
            Console.ReadLine();
        }
    }
}

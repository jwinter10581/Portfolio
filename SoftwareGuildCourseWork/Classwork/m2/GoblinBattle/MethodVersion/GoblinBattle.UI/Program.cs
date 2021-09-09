using System;

namespace GoblinBattle.UI
{
    class Program
    {
static void Main(string[] args)
{
    Goblin goblinPlayer = new Goblin();
    Goblin goblinOther = new Goblin();

    goblinPlayer.SetHitPoints(10);
    goblinPlayer.SetName("Bob");

    goblinOther.SetHitPoints(10);
    goblinOther.SetName("Tom");

    while (!goblinPlayer.GetIsDead() && !goblinOther.GetIsDead())
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

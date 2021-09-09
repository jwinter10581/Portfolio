using System;

namespace GoblinBattle.UI
{
    class Goblin
    {
        // we only need one rng for all goblin instances, so static
        private static Random _rng = new Random();
        // maximum damage to inflict
        private const int MaximumDamage = 4;

        private int _hitPoints;
        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                // if incoming value is valid, update field
                if (value >= 0)
                {
                    _hitPoints = value;
                }
            }
        }

        public string Name { get; set; }
        public bool IsDead { get; private set; }

        // attack another goblin instance (target)
        public void Attack(Goblin target)
        {
            int damage = _rng.Next(MaximumDamage + 1);
            Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage!");

            target.Hit(damage);
        }

        // for when this instance gets hit
        public void Hit(int damage)
        {
            // deduct damage
            _hitPoints -= damage;
            Console.WriteLine($"{Name} receives {damage} damage. They have {_hitPoints} health.");

            // should we die?
            if (_hitPoints <= 0)
            {
                Console.WriteLine($"{Name} has died!");
                IsDead = true;
            }
        }
    }
}

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
        private string _name;
        private bool _isDead;

        public int GetHitPoints()
        {
            return _hitPoints;
        }

        public void SetHitPoints(int hp)
        {
            // if hp valid, update field
            if (hp >= 0)
            {
                _hitPoints = hp;
            }
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string newName)
        {
            _name = newName;
        }

        public bool GetIsDead()
        {
            return _isDead;
        }

        // attack another goblin instance (target)
        public void Attack(Goblin target)
        {
            int damage = _rng.Next(MaximumDamage + 1);
            Console.WriteLine($"{_name} attacks {target.GetName()} for {damage} damage!");

            target.Hit(damage);
        }

        // for when this instance gets hit
        public void Hit(int damage)
        {
            // deduct damage
            _hitPoints -= damage;
            Console.WriteLine($"{_name} receives {damage} damage. They have {_hitPoints} health.");

            // should we die?
            if (_hitPoints <= 0)
            {
                Console.WriteLine($"{_name} has died!");
                _isDead = true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoblinBattleDos
{
    class Goblin
    {

        private static Random _rng = new Random(); // marked as static as it will be shared among all goblin objects
        private const int MaximumDamage = 4;

        private int _hitPoints;
        public int HitPoints
        {
            get { return _hitPoints; }   
            set
            {
                if (value >= 0)
                {
                    _hitPoints = value;
                }
            }
        }

        //private string _name;
        public string Name { get; set; }

        public bool IsDead { get; private set; }  

        //public int GetHitPoints()
        //{
        //    return _hitPoints;
        //}

        //public void SetHitPoints(int hp)
        //{
        //    if (hp >= 0)
        //    {
        //        _hitPoints = hp;
        //    }
        //}

        //public string GetName()
        //{
        //    return _name;
        //}

        //public void SetName(string newName)
        //{
        //    _name = newName;
        //}

        //public bool GetIsDead()
        //{
        //    return _isDead;
        //}

        public void Attack(Goblin target)
        {
            int damage = _rng.Next(MaximumDamage + 1);
            Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage!");
            target.Hit(damage);
        }

        public void Hit(int damage)
        {
            _hitPoints -= damage;
            Console.WriteLine($"{Name} recieves {damage} damage.  They have {_hitPoints} health.");

            if (_hitPoints <= 0)
            {
                Console.WriteLine($"{Name} has died!");
                IsDead = true;
            }
        }
    }
}

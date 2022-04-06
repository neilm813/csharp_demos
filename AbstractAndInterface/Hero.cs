using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractAndInterface
{
    public class Hero : IDamageable
    {
        public int Health { get; set; }
        public string Name;

        public Hero(string name)
        {
            Name = name;
            Health = 100;
        }

        public void Attack(IDamageable target)
        {
            target.TakeDamage(10);
        }

        // The default TakeDamage is inherited from IDamageable
        // public int TakeDamage(int amnt)
        // {
        //     Health -= amnt;
        //     return Health;
        // }
    }
}
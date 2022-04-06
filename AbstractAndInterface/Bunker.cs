using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractAndInterface
{
    public class Bunker : Building, IDamageable
    {
        public int Health { get; set; }
        public override string Name { get; set; }
        public bool IsShielded { get; set; } = true;

        public Bunker(string name)
        {
            Name = name;
            Health = 30;
        }

        public int TakeDamage(int amnt)
        {
            // Absorb dmg if shielded.
            if (IsShielded)
            {
                IsShielded = false;
            }
            else
            {
                Health -= amnt;
            }

            Console.WriteLine($"{Name}'s health is: {Health}");
            return Health;
        }
    }
}
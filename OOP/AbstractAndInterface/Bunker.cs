using System;

namespace AbstractAndInterface
{
    public class Bunker : Building, IDamageable
    {
        public int Health { get; set; }
        public override string Name { get; set; }
        bool isShielded = true;

        public Bunker(string name)
        {
            Name = name;
            Health = 30;
        }

        public int TakeDamage(int amnt)
        {
            // Shield absorbs 1 attack and takes no damage.
            if (isShielded)
            {
                isShielded = false;
            }
            else
            {
                Health -= amnt;
            }

            Console.WriteLine($"{Name}'s health is now: {Health}");
            return Health;
        }
    }
}
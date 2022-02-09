using System;

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

        public int Attack(IDamageable target)
        {
            return target.TakeDamage(10);
        }

        public int TakeDamage(int amnt)
        {
            Health -= amnt;
            Console.WriteLine($"{Name}'s health is now: {Health}");
            return Health;
        }
    }
}
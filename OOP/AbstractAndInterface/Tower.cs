namespace AbstractAndInterface
{
    public class Tower : Building, IDamageable
    {
        public int Health { get; set; }
        public override string Name { get; set; }

        public Tower(string name, int health = 100, int floors = 2)
        {
            Name = name;
            Health = health;

            // overwrite the default floors from the abstract building class
            Floors = floors;
        }

        // inherits the default TakeDamage method from IDamageable, can be replaced if we need to customize
    }
}
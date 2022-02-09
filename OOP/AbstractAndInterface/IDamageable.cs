namespace AbstractAndInterface
{
    public interface IDamageable
    {
        // Any class that implement this interface MUST have health
        int Health { get; set; }

        // Must have take damage FUNCTIONality
        // Method signature only, up to the child classes to define how it works
        int TakeDamage(int amnt)
        {
            Health -= amnt;
            return Health;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbstractAndInterface
{
    public interface IDamageable
    {
        // Any class that implements this interface MUST have health so it can be damaged
        public int Health { get; set; } // get set needed b/c interface can't have fields

        /* 
        This can be ONLY a method signature (just the return type, name, and params)
        which would require the child classes to define it.

        Or, we can provide a default implementation for it, that will be used,
        UNLESS the child class defines their own version.
        */
        int TakeDamage(int amnt)
        {
            Health -= amnt;
            return Health;
        }
    }
}
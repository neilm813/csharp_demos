using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP
{
    // A parent class that other classes will inherit from, such as Student, Teacher.
    public class Person
    {
        public Guid id { get; set; }
        // Auto implemented properties
        public string FirstName { get; set; }
        public string LastName { get; set; }

        /* 
        Add back the default parameterless constructor so we can construct an
        empty person if we want. The below constructor overrode the default one so we
        had to add it back if we want to use it.
        */
        public Person() { }

        /* 
        Constructors are methods that are named after the class itself.
        THey don't need a return value b/c it's implicit that a new instance is
        being returned.

        The first constructor you add will override the default
        parameterless constructor. The default constructor is no longer
        available unless you explicitly add it back. See above.
        */
        public Person(string firstName, string lastName)
        {
            id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
        }

        public string FullName()
        {
            // this.FirstName is implicit.
            return FirstName + " " + this.LastName;
        }
    }
}
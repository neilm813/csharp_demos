using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP
{
    public class Teacher : Person
    {
        public int YearsExperience { get; set; }

        /* 
        base calls the parent constructor that we inherit from.
        */
        public Teacher(string firstName, string lastName, int yearsExperience) : base(firstName, lastName)
        {

            YearsExperience = yearsExperience;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP
{
    public class Student : Person
    {
        public string CurrentStack { get; set; }

        /* 
        base calls the parent constructor that we inherit from.
        */
        public Student(string firstName, string lastName, string currentStack) : base(firstName, lastName)
        {

            CurrentStack = currentStack;
        }
    }
}
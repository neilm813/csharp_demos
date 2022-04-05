using System;
using System.Collections.Generic;

namespace OOP
{
    class Program
    {
        // Field, it's just a local var in a class.
        int x = 5;

        // Private backing field, it is 'back' behind the Msg property.
        private string msg = "this is a private field.";

        // Properties have get and set.
        public string Msg
        {
            get
            {
                if (msg.Length == 0)
                {
                    return "No message. Please set one.";
                }

                return msg;
            }
            // Setting is assignment, value keyword holds the data to the right of the = sign.
            set
            {
                if (msg.Length > 0)
                {
                    msg = value;
                }
            }
        }

        // Auto-implemented prop, the private backing field is automatically implemented but invisible to us.
        public int TestNum { get; set; }
        static void Main(string[] args)
        {
            /* Ways to assign data to class properties when instantiating: */
            // Person p1 = new Person();
            // p1.FirstName = "test";

            // Console.WriteLine(p1.FirstName);

            Person p1 = new Person()
            {
                FirstName = "FN",
                LastName = "LN"
            };
            // Console.WriteLine(p1.FirstName);

            Person person = new Person("FN", "LN");

            Student ben = new Student("Ben", "Rosenberg", "C#");
            Student peter = new Student("Peter", "Snider", "C#");
            Student kyle = new Student("Kyle", "Stouffer", "C#");

            List<Student> csharpStudents = new List<Student>()
            {
                ben,
                peter,
                kyle
            };

            Teacher neil = new Teacher("Neil", "Mos", 4);

            Lecture oopIntro = new Lecture("OOP Intro", new DateTime(2022, 4, 5, 10, 15, 0), neil, csharpStudents);

            oopIntro.PrintAttendanceList();
        }
    }
}

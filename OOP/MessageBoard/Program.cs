using System;

namespace MessageBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
            Use OOP to create message boards and users that can send messages on the
            message boards.
            */

            // dataType varName = someValue;
            int x = 5;

            // Every class becomes a data type.
            Message message1 = new Message("test content.");

            Person person1 = new Person("Anthony", "Do", 26);

            Person person2 = new Person("Liz", "G");

            Console.WriteLine(person1);
            Console.WriteLine(person2);
        }
    }
}

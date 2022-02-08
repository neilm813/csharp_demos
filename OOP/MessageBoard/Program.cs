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
            Person person1 = new Person("Liz", "G");

            User user1 = new User("TonyDo", "ad@gmail.com", "Anthony", "Do", 26);

            Console.WriteLine(person1);
            Console.WriteLine(user1);

            Message message1 = new Message(user1, "test content.");

            user1.SendMessage(new Message("blah test message"));
            user1.SendMessage(new Message("test2"));



            // Console.WriteLine(message1.Author);
            // Console.WriteLine(user1.Messages[1].Content);

            user1.PrintMessages();
        }
    }
}

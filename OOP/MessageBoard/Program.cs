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
            User liz = new User("GGLiz", "lg@gmail.com", "Liz", "G");

            User tony = new User("TonyDo", "ad@gmail.com", "Anthony", "Do", 26);

            Console.WriteLine(liz);
            Console.WriteLine(tony);

            Board stonks = new Board("Stonks", "Discuss stonks and stonk strategies.");

            Board doggos = new Board("Doggos", "The good and the bad doggos and everything inbetween. NO PUPPERS, only doggos.");

            Board learnToCode = new Board("Learn To Code", "For people learning to code.");

            tony.SendMessage(stonks, "I saw elongated musket make a tweet, buy now!");
            tony.SendMessage(doggos, "Shibes are my favorite doggo.");
            liz.SendMessage(doggos, "My choco lab, Harley, is a good boi!");

            tony.SendMessage(learnToCode, "C# be like Confusion confusion = new Confusion();");

            // Console.WriteLine(message1.Author);
            // Console.WriteLine(user1.Messages[1].Content);

            tony.PrintMessages();

            doggos.Messages[0].Content = "new content";


        }
    }
}

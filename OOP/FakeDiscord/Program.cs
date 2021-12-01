using System;

namespace FakeDiscord
{
    class Program
    {
        static void Main(string[] args)
        {
            // Construct/instantiate empty user:
            // User testUser = new User();
            // testUser.Username = "test"; // trigger the setter
            // Console.WriteLine(testUser.Username); // trigger the getter

            User james = new User(1, "cool-james", "james@me.com");

            User blair = new User(2, "cool-blair", "blair@me.com");

            Guild dojo = new Guild(1, "The Coding Dojo");
            new TextChannel(dojo, 1, "🏫cohort-Cody");
            new TextChannel(dojo, 2, "📗csharp");

            Guild python = new Guild(2, "Python Community");
            new TextChannel(python, 1, "Python Fundamentals");
            new TextChannel(python, 2, "Machine Learning");

            dojo.Join(james);
            python.Join(james);
            dojo.Join(blair);

            Console.WriteLine(james);
            Console.WriteLine(dojo);

            dojo.PrintMembers();
            python.PrintMembers();
            james.PrintGuilds();

            james.SendMessage("You betta hope you got a high dex when you roll initiative!");
            james.SelectChannel(dojo.TextChannels[0]);

            james.SendMessage("Hinkle Finkle Dinkle Doo.");
            blair.SendMessage("Don't put me on the spot, bro!.");

        }
    }
}

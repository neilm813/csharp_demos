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

            dojo.Join(james);
            dojo.Join(james);
            dojo.Join(blair);

            Console.WriteLine(james);
            Console.WriteLine(dojo);
        }
    }
}
